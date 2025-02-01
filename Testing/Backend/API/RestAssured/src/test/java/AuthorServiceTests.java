import static io.restassured.RestAssured.given;
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

    @Test
    public void create_author_returns_200_and_created_author() {
        var id = given().
            body("{\"name\": \"Jorge Luis Borges\", \"gender\": \"Male\", \"nationality\": \"Argentinian\"}").
            header("Content-Type", "application/json").
        when().
            post("/").
        then().
            statusCode(200).
            body("name", equalTo("Jorge Luis Borges"),
            "gender", equalTo("Male"),
            "nationality", equalTo("Argentinian")).extract().path("id");
        
        when().
            get("/" + id).
        then().
            statusCode(200).
            body("id", equalTo(id),
                "name", equalTo("Jorge Luis Borges"));
    }

    @Test
    public void create_author_with_missing_fields_returns_400() {
        given().
            body("{\"name\": \"Jorge Luis Borges\"}").
            header("Content-Type", "application/json").
        when().
            post("/").
        then().
            statusCode(400);
    }
}
