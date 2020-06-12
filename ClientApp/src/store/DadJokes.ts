export interface DadJokesResponse {
    totalJokes: number,
    results: string,
    term: string
}

export interface DadJoke {
    joke: string,
    sizeDescription: string
}

const FetchJokes = (term: string, action: any) => {
    console.log(term);
    fetch(`api/dadjokes/` + term)
        .then(response => response.json())
        .then(data => {
            console.log(data);
            var response: DadJokesResponse = {
                results: JSON.stringify(data.results),
                totalJokes: data.totalJokes,
                term: data.term
            };
            action(response);
        });
}

export default FetchJokes;