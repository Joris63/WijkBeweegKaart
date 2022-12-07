import ProgressBar from "./ProgressBar";
import Question from "./Question";

const Survey = () => {
  return (
    <div className="survey_wrapper">
      <ProgressBar progress={0.25} percentage />
      <Question />
    </div>
  );
};

export default Survey;

/*
import React, {Component} from 'react';
import SurveyService from '../../services/SurveyService'
import { ProgressBar } from 'react-bootstrap';

class SurveyQuestions extends Component {

  state = {
    questions: [],
    pageNumber: 0,
    selections: [],
    json: {pages: []}
}

componentDidMount() {
    SurveyService.getAll()
        .then(res => {
            this.setState({ questions: res.data.pages });
            this.createSelections();        
        })
}

createSelections()
{
  for(let i=0; i < this.state.questions.length; i++)
  {
    let other = false;
    let openEnded = false;
    let inputFamily = this.state.questions[i]?.questions[0].family;           

    if(this.state.questions[i]?.questions[0]?.answers?.other)
    {
        other = true;
    }  

    switch(inputFamily)
    {
        case"single_choice":
            this.state.selections.push({value:"", type:inputFamily, openEnded:openEnded, other:other})
            break;
        case"multiple_choice":
            let chekboxArray = [];
            for(let y=0; y < this.state.questions[i]?.questions[0].answers?.choices.length; y++)
            {
              chekboxArray.push({value: ""})
            }
            this.state.selections.push({values:chekboxArray, type:inputFamily, openEnded:openEnded, other:other})
            break;
        case"open_ended":
            openEnded = true;
            this.state.selections.push({value:"", openEnded:openEnded, other:other})
    }
  }
  this.setState(this.state.selections)
}


postSurvey = () =>
{
  for(let i=0; i < this.state.questions.length; i++)
  {
    this.state.json.pages.push({"id": this.state.questions[i]?.id, 
    "questions" : [{"id": this.state.questions[i]?.questions[0].id, "answers": []}]})

    switch(this.state.questions[i]?.questions[0].family)
    {
        case"single_choice":
            this.state.json.pages[i].questions[0].answers.push({"choice_id" : this.state.selections[i].value})
            break;
        case"multiple_choice":
            for(let y=0; y < this.state.selections[i].values.length; y++)
            {
              if(this.state.selections[i].values[y].value !== '')
              {
                this.state.json.pages[i].questions[0].answers.push({"choice_id" : this.state.selections[i].values[y].value})
              }
            }
            break;
        case"open_ended":
            this.state.json.pages[i].questions[0].answers.push({"text" : this.state.selections[i].value})
    }
  }
  this.setState(this.state.json.pages)
  console.log(this.state.json)

  SurveyService.post(this.state.json)
  .then(res => {
    console.log(res)
  }).catch((error) => {console.log(error)});
}

handleNextPage = () =>
{
    this.setState({pageNumber : this.state.pageNumber + 1})
}

handlePreviousPage = () =>
{
    this.setState({pageNumber : this.state.pageNumber - 1})
}

handleRadioInput(value) {
  this.state.selections[this.state.pageNumber].value = value;
  this.setState(this.state.selections)
}

handleCheckboxInput(event, value, index) {
  if(!event.target.checked)
  {
    this.state.selections[this.state.pageNumber].values[index].value = '';
  }
  else
  {
  this.state.selections[this.state.pageNumber].values[index].value = value;
  }
  this.setState(this.state.selections)
  console.log(this.state.selections)
}

handleTextboxInput(event) {
this.state.selections[this.state.pageNumber].value = event.target.value;
this.setState(this.state.selections)
}

    render() {

        let progress = 100 / (this.state.questions.length -1) * this.state.pageNumber

        return (
            <div className='container'>
            <div className='w-75 justify-content-center container'>
  
                <br></br>
                <ProgressBar striped variant='warning' now={progress} />
                <br></br>
                {this.state.questions[this.state.pageNumber]?.questions.map(question => <div key={question.id}>

                <label><h4>{question.headings[0].heading}</h4></label>


                { this.state.selections[this.state.pageNumber]?.type === "single_choice" ? 

                question.answers?.choices.map(choice => <div className='form-group' key={choice.id}>
                  <input checked={this.state.selections[this.state.pageNumber]?.value === choice.id} onChange={() => this.handleRadioInput(choice.id)} 
                  className='m-1' type="radio" name={question.id} value={choice.id}></input>
                  { choice.text}
                  </div>
                  )
                  : null
                }

                { this.state.selections[this.state.pageNumber]?.type === "multiple_choice" ? 

                question.answers?.choices.map((choice, index) => <div className='form-group' key={choice.id}>
                  <input checked={this.state.selections[this.state.pageNumber]?.values[index]?.value === choice.id} onChange={(e) => this.handleCheckboxInput(e,choice.id, index)} 
                  className='m-1' type="checkbox" name={question.id} value={choice.id}></input>
                  { choice.text}
                  </div>
                  )
                  : null
                }

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
                  {this.state.pageNumber !== this.state.selections.length - 1 ?
                <button style={{float: "right"}} className='btn btn-warning' type="button" onClick={this.handleNextPage}>Next</button> 
                :
                <button style={{float: "right"}} className='btn btn-warning' type="button" onClick={this.postSurvey}>Sumbit</button> 
                  }
            </div>
            </div>
        )
    }
}
export default SurveyQuestions
*/