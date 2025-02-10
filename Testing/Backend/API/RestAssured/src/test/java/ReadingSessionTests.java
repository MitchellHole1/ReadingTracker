import static io.restassured.RestAssured.given;
import static io.restassured.RestAssured.when;
import static org.hamcrest.Matchers.*;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import org.junit.jupiter.params.provider.ValueSource;

import io.restassured.RestAssured;
import io.restassured.filter.log.RequestLoggingFilter;
import io.restassured.filter.log.ResponseLoggingFilter;

public class ReadingSessionTests {
    
    @BeforeAll
    public static void initialize() {
        RestAssured.baseURI = "http://localhost:5099";
        RestAssured.basePath = "/api/ReadingSession";
        RestAssured.filters(new RequestLoggingFilter(), new ResponseLoggingFilter());
    }

    @Test
    public void get_all_reading_sessions_returns_200_and_all_reading_sessions() {
        when().
            get("/").
        then().
            statusCode(200).
            body("$", hasSize(greaterThanOrEqualTo(2)),
                "$", hasItem(allOf(
                    hasKey("bookId"),
                    hasKey("book"),
                    hasKey("start"),
                    hasKey("end"),
                    hasKey("rating"),
                    hasKey("id")
                )));
    }

    @Test
    public void get_reading_session_by_id_returns_200_and_expected_reading_session() {
        when().
            get("/1").
        then().
            statusCode(200).
            body("id", equalTo(1),
                "bookId", equalTo(1),
                "book.name", equalTo("Blood Meridian"),
                "rating", equalTo(100));
    }

    @Test
    public void get_reading_session_by_non_existing_id_returns_404() {
        when().
            get("/100").
        then().
            statusCode(404);
    }

    @Test
    public void get_current_reading_session_returns_200_and_expected_reading_session() {
        when().
            get("/current").
        then().
            statusCode(200).
            body("$", hasSize(2),
                "$", hasItem(allOf(
                    hasKey("bookId"),
                    hasKey("book"),
                    hasKey("start"),
                    not(hasKey("end")),
                    not(hasKey("rating")),
                    hasKey("id")
                )));
    }

    @Test
    public void create_reading_session_returns_200_and_created_reading_session() {
        given().
            body("{\"bookId\": 2, \"start\": \"2021-01-01T00:00:00Z\", \"end\": \"2021-01-31T00:00:00Z\", \"rating\": 100}").
            header("Content-Type", "application/json").
        when().
            post("/").
        then().
            statusCode(200).
            body("bookId", equalTo(2),
                "start", equalTo("2021-01-01T00:00:00Z"),
                "end", equalTo("2021-01-31T00:00:00Z"),
                "rating", equalTo(100));
    }

    @Test
    public void create_reading_session_with_invalid_book_id_returns_400() {
        given().
            body("{\"bookId\": 100, \"start\": \"2021-01-01T00:00:00Z\", \"end\": \"2021-01-31T00:00:00Z\", \"rating\": 100}").
            header("Content-Type", "application/json").
        when().
            post("/").
        then().
            statusCode(400);
    }

    @ParameterizedTest
    @CsvSource({"2021-01-01T00:00:00Z, 2021-01-31", "2021-01-01, 2021-01-31T00:00:00Z"})
    public void create_reading_session_with_invalid_dates_returns_400(String start, String end) {
        given().
            body(String.format("{\"bookId\": 2, \"start\": %s, \"end\": %s, \"rating\": 100}", start, end)).
            header("Content-Type", "application/json").
        when().
            post("/").
        then().
            statusCode(400);
    }

    @Test
    public void create_reading_session_with_start_after_end_returns_400() {
        given().
            body("{\"bookId\": 2, \"start\": \"2021-01-31T00:00:00Z\", \"end\": \"2021-01-01T00:00:00Z\", \"rating\": 100}").
            header("Content-Type", "application/json").
        when().
            post("/").
        then().
            statusCode(400).
            body(containsString("Start date is after end date"));
    }

    @ParameterizedTest
    @ValueSource(ints = {-1, 101})
    public void create_reading_session_with_invalid_rating_returns_400(int rating) {
        given().
            body("{\"bookId\": 2, \"start\": \"2021-01-01T00:00:00Z\", \"end\": \"2021-01-31T00:00:00Z\", \"rating\": " + rating + "}").
            header("Content-Type", "application/json").
        when().
            post("/").
        then().
            statusCode(400)
            .body("errors.Rating", hasItem("The field Rating must be between 0 and 100."));
    }

}
