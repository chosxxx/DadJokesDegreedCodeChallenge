"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var DadJokes = function (props) {
    var totalJokes = props.totalJokes;
    var jokesList = JSON.parse(props.results);
    var rows = [];
    var currentSize = "";
    for (var i = 0; i < jokesList.length; i++) {
        if (currentSize != jokesList[i].sizeDescription) {
            rows.push(React.createElement("tr", { className: "size-name" },
                React.createElement("td", { colSpan: 2 }, jokesList[i].sizeDescription)));
            currentSize = jokesList[i].sizeDescription;
        }
        var pattern = new RegExp(props.term, 'gi');
        var jokeText = jokesList[i].joke.replace(pattern, function (s) { return "<b>" + s + "</b>"; });
        rows.push(React.createElement("tr", null,
            React.createElement("td", null, i + 1),
            React.createElement("td", { dangerouslySetInnerHTML: { __html: jokeText } })));
    }
    return (React.createElement("table", null,
        React.createElement("tr", null,
            React.createElement("td", { className: "leading-column" }, "Total jokes:"),
            React.createElement("td", null, totalJokes)),
        rows));
};
exports.default = DadJokes;
//# sourceMappingURL=DadJokes.js.map