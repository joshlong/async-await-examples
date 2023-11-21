use serde::Deserialize;
use reqwest;

#[derive(Deserialize, Debug)]
struct CatFact {
    fact: String,
}

#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error>> {
    let url = "https://catfact.ninja/fact";
    let response = reqwest::get(url).await?.json::<CatFact>().await?;

    println!("Fact: {}", response.fact);

    Ok(())
}
