import React, {Component} from 'react';
import SurveyService from '../../services/SurveyService'

class SurveyQuestions extends Component {

  state = {
    questions: [],
    pageNumber: 0
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
    console.log(this.state.pageNumber)
}

handlePreviousPage = () =>
{
    this.setState({pageNumber : this.state.pageNumber - 1})
    console.log(this.state.pageNumber)
}

    render() {

        var inputType;
        var other = false;
        if(this.state.questions[this.state.pageNumber]?.questions[0].family === "single_choice")
        {
            inputType = "radio";
        }

        if(this.state.questions[this.state.pageNumber]?.questions[0].answers.other)
        {
            other = true;
        }   

        return (
            <div className='container'>
            <div className='w-75 justify-content-center container'>
  
                <br></br>
                {this.state.questions[this.state.pageNumber]?.questions.map(question => <div key={question.id}>

                <label><h4>{question.headings[0].heading}</h4></label>
                {question.answers.choices.map(choice => <div className='form-group' key={choice.id}>
                  <input  type={inputType} name={question.id} value={choice.id}></input>
                  { choice.text}
                  </div>
                  )}
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
