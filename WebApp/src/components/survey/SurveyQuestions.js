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

            for(let i=0; i < this.state.questions.length; i++)
            {
              let other = false;
              let openEnded = false;
              let inputType;
              let inputFamily = this.state.questions[i]?.questions[0].family;           

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

              if(this.state.questions[i]?.questions[0]?.answers?.other)
              {
                  other = true;
              }  

              this.state.selections.push({value:"", type:inputType, openEnded:openEnded, other:other,})   
              
            }
            this.setState(this.state.selections)

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
  this.state.selections[this.state.pageNumber].value = value;
  this.setState(this.state.selections)
  console.log(this.state.selections)
  }

  handleTextboxInput(event) {
    this.state.selections[this.state.pageNumber].value = event.target.value;
    this.setState(this.state.selections)
    }

    render() {

        let progress = 100 / this.state.questions.length * this.state.pageNumber

        return (
            <div className='container'>
            <div className='w-75 justify-content-center container'>
  
                <br></br>
                <ProgressBar striped variant='warning' now={progress} />
                <br></br>
                {this.state.questions[this.state.pageNumber]?.questions.map(question => <div key={question.id}>

                <label><h4>{question.headings[0].heading}</h4></label>

                {question.answers?.choices.map(choice => <div className='form-group' key={choice.id}>
                  <input checked={this.state.selections[this.state.pageNumber]?.value === choice.id} onChange={() => this.handleInput(choice.id)} 
                  className='m-1' type={this.state.selections[this.state.pageNumber]?.type} name={question.id} value={choice.id}></input>
                  { choice.text}
                  </div>
                  )}

                { this.state.selections[this.state.pageNumber]?.openEnded === true ? 
                    <div className='form-group'>
                    <input value={this.state.selections[this.state.pageNumber]?.value} onChange={(e) => this.handleTextboxInput(e)}   type='text'></input>                     
                    </div> : null
                }

                  <br></br>
                  { this.state.selections[this.state.pageNumber]?.other === true ? 
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
