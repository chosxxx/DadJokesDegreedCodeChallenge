import * as React from 'react';
import { DadJokesResponse, DadJoke } from '../store/DadJokes';

const DadJokes = (props: DadJokesResponse) => {
    var totalJokes = props.totalJokes;
    var jokesList = JSON.parse(props.results) as DadJoke[];
    let rows = [] as JSX.Element[];
    var currentSize = "";
    for (var i = 0; i < jokesList.length; i++) {
        if (currentSize != jokesList[i].sizeDescription) {
            rows.push(<tr className="size-name"><td colSpan={2}>{jokesList[i].sizeDescription}</td></tr>);
            currentSize = jokesList[i].sizeDescription;
        }
        var pattern = new RegExp(props.term, 'gi');
        var jokeText = jokesList[i].joke.replace(pattern, (s) => "<b>" + s + "</b>");
        rows.push(<tr><td>{i + 1}</td>
            <td dangerouslySetInnerHTML={{ __html: jokeText }}/></tr>);
    }

    return (
        <table>
            <tr><td className="leading-column">Total jokes:</td><td>{totalJokes}</td></tr>
            {rows}
        </table>
    );
}

export default DadJokes;