import static io.restassured.RestAssured.when;
import static org.hamcrest.Matchers.*;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import io.restassured.RestAssured;
import io.restassured.filter.log.RequestLoggingFilter;
import io.restassured.filter.log.ResponseLoggingFilter;

public class AuthorServiceTests {

    @BeforeAll
    public static void initialize() {
        RestAssured.baseURI = "http://localhost:3000";
        RestAssured.basePath = "/api/author";
        RestAssured.filters(new RequestLoggingFilter(), new ResponseLoggingFilter());
    }

    @Test
    public void get_all_authors_returns_200_and_all_authors() {        
        when().
            get("/").
        then().
            statusCode(200).
            body("results", hasSize(10),
            "results", hasItem(allOf(
                hasEntry("name", "Albert Camus"),
                hasEntry("gender", "Male"),
                hasEntry("nationality", "French")
            )),
                "offset", equalTo(0),
                "limit", equalTo(10));
    }

    @Test
    public void get_author_by_id_returns_200_and_expected_author() {
        when().
            get("/1").
        then().
            statusCode(200).
            body("id", equalTo(1),
                "name", equalTo("Cormac McCarthy"),
                "nationality", equalTo("American")
            );
    }

    @Test
    public void get_author_by_non_existing_id_returns_404() {
        when().
            get("/100").
        then().
            statusCode(404);
    }
}
