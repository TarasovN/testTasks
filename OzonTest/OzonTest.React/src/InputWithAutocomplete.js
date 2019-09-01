import React, { Component } from "react";
import axios from "axios";
import Autocomplete from './Autocomplete';

class InputWithAutocomplete extends React.Component {

    constructor(props) {
        super(props);
        this.getSuggestions = this.getSuggestions.bind(this);
        this.onInputChanged = this.onInputChanged.bind(this);
        this.state = {
            suggestions: []
        };
    }

    getSuggestions(input) {
        axios.get("https://localhost:44336/api/suggest",
            { params: { input: input } }
        ).then((response) => {                       
            
            this.setState({
                suggestions : response.data
            })
        })
    }

    onInputChanged(input) {
        if (input.length > 0) {
            this.getSuggestions(input);
        }
        else{
            this.setState({
                suggestions : []
            })
        }
    }


    render() {
        const {
            state: {
                suggestions
            }
        } = this;        
        return <Autocomplete
            suggestions={suggestions} onInputChanged={this.onInputChanged}
        />;
    }
}

export default InputWithAutocomplete;