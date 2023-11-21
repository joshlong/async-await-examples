import threading
import asyncio
import json
import aiohttp


async def fetch_website_data(url):
    async with (aiohttp.ClientSession() as session,
                session.get(url) as response):
        assert response.status == 200, 'the response was not 200'
        return await response.text()


async def main():
    website_data = await fetch_website_data(url="https://catfact.ninja/fact")
    print(f"Fact:", json.loads(website_data)['fact'])


# Run the main function using asyncio
asyncio.run(main())
