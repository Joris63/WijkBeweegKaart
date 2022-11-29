import React, {Component} from 'react';
import SurveyService from '../../services/SurveyService'

class SurveyQuestions extends Component {

  state = {
    questions: [],
}

componentDidMount() {
    SurveyService.getAll()
        .then(res => {
            this.setState({ questions: res.data.pages });
            console.log(this.state.questions)
        })
}
    render() {
        return (
           <div>
                {this.state.questions[0]?.questions[0].headings[0].heading}
                <br></br>
                {this.state.questions[0]?.questions[0].answers.choices.map(choice => <div className="col-md-auto text-center" key={choice.id}>
                  {choice.text}
                  </div>
                  )}
                {}
           </div>
        )
    }
}
export default SurveyQuestions
