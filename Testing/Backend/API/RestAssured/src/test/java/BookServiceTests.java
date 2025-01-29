import io.restassured.RestAssured;
import io.restassured.filter.log.RequestLoggingFilter;
import io.restassured.filter.log.ResponseLoggingFilter;

import org.apache.http.HttpStatus;
import org.hamcrest.Matchers;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static io.restassured.RestAssured.*;
import static org.hamcrest.Matchers.*;

public class BookServiceTests {

    @BeforeAll
    public static void initialize() {
        RestAssured.baseURI = "http://localhost:3000";
        RestAssured.basePath = "/api/book";
        RestAssured.filters(new RequestLoggingFilter(), new ResponseLoggingFilter());
    }

    @Test
    public void get_all_books_returns_200_and_all_books() {
        when().
            get("/").
        then().
            statusCode(200).
            body("$", hasSize(greaterThanOrEqualTo(8)));
    }

    @Test
    public void get_book_by_id_returns_200_and_expected_book() {
        when().
            get("/1").
        then().
            statusCode(HttpStatus.SC_OK).
            body("id", equalTo(1),
            "name", equalTo("Blood Meridian"),
                    "yearPublished", equalTo(1985),
                    "author.name", equalTo("Cormac McCarthy"));
    }

    @Test
    public void get_book_by_non_existing_id_returns_404() {
        when().
            get("/100").
        then().
            statusCode(HttpStatus.SC_NOT_FOUND);
    }

}
