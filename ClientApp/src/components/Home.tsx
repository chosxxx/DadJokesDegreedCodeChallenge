import React, { useState } from 'react';
import DadJokes from './DadJokes';
import FetchDadJokes, { DadJokesResponse } from '../store/DadJokes';

function Home() {
    var termText = "";
    var [totalJokes, setTotalJokes] = useState(0);
    var [jokeList, setJokeList] = useState("{}");
    var [term, setTerm] = useState(termText);

    const DisplayJokes = (data: DadJokesResponse) => {
        setTotalJokes(data.totalJokes);
        setJokeList(data.results);
        setTerm(termText);
    };

    const getRandom = () => FetchDadJokes("", DisplayJokes);
    const searchJokes = () => {
        termText = (document.getElementById("txtTerm") as HTMLInputElement).value;

        if (termText.length < 3)
            alert("Please enter at least 3 characters")
        else
            FetchDadJokes(termText, DisplayJokes);
    }

    const txtKeyUp = (event: any) => {
        console.log(event.keyCode);
        if (event.keyCode === 13) {
            event.preventDefault();
            searchJokes();
        }
    }

    return (
        <div className="App">
            <div className="SearchControls">
                <input type="text" id="txtTerm" width="150px" onKeyUp={txtKeyUp} autoFocus={true} /><span />
                <button id="btnSearch" onClick={searchJokes}>Search</button>
                <button onClick={getRandom}>Get random</button>
            </div>
            <div>
                <DadJokes term={term} totalJokes={totalJokes} results={jokeList} />
            </div>
        </div>
    );
}

export default Home;
