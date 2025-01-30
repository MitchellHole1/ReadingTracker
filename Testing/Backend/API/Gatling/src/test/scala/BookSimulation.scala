import io.gatling.core.Predef._
import io.gatling.core.structure.ScenarioBuilder
import io.gatling.http.Predef._

class BookSimulation extends Simulation {
  val numUsers = 10
  val duration = 60
  val rampUp = 10

  val getBooksScenario: ScenarioBuilder = scenario("Get All Books").exec(
    http("Get Books")
      .get("book")

  ).pause(1)

  val httpProtocol =
    http.baseUrl("http://localhost:5099/api/")
      .acceptHeader("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8")
      .acceptLanguageHeader("en-US,en;q=0.5")
      .acceptEncodingHeader("gzip, deflate")
      .userAgentHeader(
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:109.0) Gecko/20100101 Firefox/119.0"
      )

  setUp(
    getBooksScenario.inject(
      rampConcurrentUsers(0) to (numUsers) during (rampUp),
      constantConcurrentUsers(numUsers) during (duration)
    )
  ).protocols(httpProtocol)
}