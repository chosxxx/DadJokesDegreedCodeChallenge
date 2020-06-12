"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var FetchJokes = function (term, action) {
    console.log(term);
    fetch("api/dadjokes/" + term)
        .then(function (response) { return response.json(); })
        .then(function (data) {
        console.log(data);
        var response = {
            results: JSON.stringify(data.results),
            totalJokes: data.totalJokes,
            term: data.term
        };
        action(response);
    });
};
exports.default = FetchJokes;
//# sourceMappingURL=DadJokes.js.map