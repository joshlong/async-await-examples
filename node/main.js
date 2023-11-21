const https = require('https');

function fetchCatFact() {
    return new Promise((resolve, reject) => {
        const url = 'https://catfact.ninja/fact';
        https.get(url, (res) => {
            let data = '';
            res.on('data', (chunk) =>  data += chunk );
            res.on('end', () => resolve(JSON.parse(data)) );
        }) 
    });
}

async function main() {
const catFact = await fetchCatFact();
console.log(`Fact: ${catFact.fact}`);
}

main();
