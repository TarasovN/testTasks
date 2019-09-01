import React, { Component } from "react";
import PropTypes from "prop-types";

export class Autocomplete extends Component {
  static propTypes = {
    suggestions: PropTypes.instanceOf(Array),
    onInputChanged: PropTypes.func 
  };
  static defaultProperty = {
    suggestions: []
  };
  constructor(props) {
    super(props);
    this.state = {
      activeSuggestion: 0,      
      showSuggestions: false,
      userInput: ""
    };
  }

  onChange = e => {    
    const userInput = e.currentTarget.value;
    this.props.onInputChanged(userInput);    

    this.setState({
      activeSuggestion: 0,      
      showSuggestions: true,
      userInput: e.currentTarget.value
    });
  };

  onClick = e => {
    this.setState({
      activeSuggestion: 0,      
      showSuggestions: false,
      userInput: e.currentTarget.innerText
    });
  };

  render() {
    const {
      onChange,
      onClick,     
      state: {
        activeSuggestion,       
        showSuggestions,
        userInput
      }
    } = this;
    let suggestionsListComponent;
    if (showSuggestions && userInput) {        
      if (this.props.suggestions.length) {
        suggestionsListComponent = (
          <ul class="suggestions">
            {this.props.suggestions.map((suggestion, index) => {
              let className;

              if (index === activeSuggestion) {
                className = "";
              }

              return (
                <li key={suggestion} onClick={onClick}>
                  {suggestion}
                </li>
              );
            })}
          </ul>
        );
      } else {
        suggestionsListComponent = (
          <div class="no-suggestions">
            <em>No suggestions</em>
          </div>
        );
      }
    }

    return (
      <React.Fragment>
        <input
          type="search"
          onChange={onChange}          
          value={userInput}
        />
        {suggestionsListComponent}
      </React.Fragment>
    );
  }
}

export default Autocomplete;
