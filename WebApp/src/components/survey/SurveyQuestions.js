import React, {Component} from 'react';
import * as Survey  from 'survey-react';
import "survey-react/survey.css"
import {questions} from './questions';

class SurveyQuestions extends Component {

  constructor(props) {
    super(props);
    this.state = {
    }
    this.onCompleteComponent = this.onCompleteComponent.bind(this)

  }

  onCompleteComponent = () =>
  {
    this.setState({
      isCompleted: true
    })
  }
  
    render() {

      var surveyRender = !this.state.isCompleted ? (
        <Survey.Survey
          json={questions}
          showCompletedPage={false}
          onComplete={this.onCompleteComponent}
        />
      ) : null
    
      var onSurveyCompeltion = this.state.isCompleted ? (
        <div>Completed</div>
      ) : null;

        return (
           <div>
              <div>
              {surveyRender}
              {onSurveyCompeltion}
              </div>
           </div>
        )
    }
}
export default SurveyQuestions
