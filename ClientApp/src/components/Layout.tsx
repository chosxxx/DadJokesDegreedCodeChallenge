import * as React from 'react';
import { Container } from 'reactstrap';

export default (props: { children?: React.ReactNode }) => (
    <React.Fragment>
        <Container>
            <div className="challenge-desc">
                <h1>Degreed code challenge</h1>
                <h3>Carlos Carrillo</h3>
                <p>
                    <strong>Challenge</strong>
                    <br />
                    Create an application that uses the &quot;I can haz dad joke&quot; api (
                    <a target="https://icanhazdadjoke.com/api">https://icanhazdadjoke.com/api</a>) 
                    to display jokes. The front-end code should be as simple as possible.  Use any front-end mechanism you wish but keep it simple.
                    <br /><br />
                    We're interested in how you design and implement the back-end service. As such, all the communication with the icanhazdadjoke API and preparing the data for display should be implemented in a back-end service using C# and .NET.
                    <br /><br />
                    There should be two options the user can choose from:
                    <br /><br />
                    <ul>
                        <li>Fetch a random joke.</li>
                        <li>Accept a search term and display the first 30 jokes containing that term.  The matching term should be emphasized in some simple way (upper, quotes, angle brackets, etc.).  The matching jokes should be grouped by length: Short (&lt;50 words), Medium (&lt;100 words), Long (&gt;= 100 words)</li>
                    </ul>
                </p>
            </div>
            <div className="challenge-solution">
                    {props.children}
            </div>
        </Container>
    </React.Fragment>
);
