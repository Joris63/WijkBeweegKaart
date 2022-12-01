import React, {Component} from 'react';
import SurveyService from '../../services/SurveyService'
import { ProgressBar } from 'react-bootstrap';

class SurveyQuestions extends Component {

  state = {
    questions: [],
    pageNumber: 0,
    selections: []
}

componentDidMount() {
    SurveyService.getAll()
        .then(res => {
            this.setState({ questions: res.data.pages });
            console.log(this.state.questions)
        })
}

handleNextPage = () =>
{
    this.setState({pageNumber : this.state.pageNumber + 1})
}

handlePreviousPage = () =>
{
    this.setState({pageNumber : this.state.pageNumber - 1})
}

handleInput(value) {
    this.setState({
      value: value
    });
  }

    render() {
        var inputType;
        var other = false;
        var openEnded = false;
        var inputFamily = this.state.questions[this.state.pageNumber]?.questions[0].family;

        var progress = 100 / this.state.questions.length * this.state.pageNumber

        switch(inputFamily)
        {
            case"single_choice":
                inputType = "radio";
                break;
            case"multiple_choice":
                inputType = "checkbox";
                break;
            case"open_ended":
                openEnded = true;
        }

        if(this.state.questions[this.state.pageNumber]?.questions[0]?.answers?.other)
        {
            other = true;
        }   

        return (
            <div className='container'>
            <div className='w-75 justify-content-center container'>
  
                <br></br>
                <ProgressBar striped variant='warning' now={progress} />
                <br></br>
                {this.state.questions[this.state.pageNumber]?.questions.map(question => <div key={question.id}>

                <label><h4>{question.headings[0].heading}</h4></label>

                {question.answers?.choices.map(choice => <div className='form-group' key={choice.id}>
                  <input checked={this.state.value === choice.id} onChange={() => this.handleInput(choice.id)} 
                  className='m-1' type={inputType} name={question.id} value={choice.id}></input>
                  { choice.text}
                  </div>
                  )}

                { openEnded === true ? 
                    <div className='form-group'>
                    <input type='text'></input>                     
                    </div> : null
                }

                  <br></br>
                  { other === true ? 
                  <div>
                  {question.answers.other.text}
                    <br></br>                  
                    <textarea className='form-control'></textarea> 
                    <br></br>  
                  </div>
                    : null
                  }   
                  </div>
                  )}
            </div>
            <div className='fixed-bottom p-5'>
            {this.state.pageNumber !== 0 ?
                  <button className='btn btn-warning' type="button" onClick={this.handlePreviousPage}>Terug</button>
                  : null
                  }   
                <button style={{float: "right"}} className='btn btn-warning' type="button" onClick={this.handleNextPage}>Next</button>
            </div>
            </div>
        )
    }
}
export default SurveyQuestions
