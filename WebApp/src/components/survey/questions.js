export const questions = {
  pages: [{

    elements: [{
      type: "html",
      html: "<h2>In this survey, we will ask you a couple questions about your impressions of our product.</h2>"
    }]
  }, 
  
  {
    elements: [{
      name: "age",
      title: "Wat is uw leeftijd?",
      type: "radiogroup",
      choices: [
        { value: 5, text: "10-20" },
        { value: 4, text: "21-30" },
        { value: 3, text: "31-40" },
        { value: 2, text: "41-50" },
        { value: 1, text: "51+" }
      ],
      isRequired: true
    }]
  },

  {
    elements: [{
      name: "gender",
      title: "Wat is uw geslacht?",
      type: "radiogroup",
      choices: [
        { value: 5, text: "Man" },
        { value: 4, text: "Vrouw" },
        { value: 3, text: "Vul ik liever niet in" },
      ],
      isRequired: true
    }]
  },

],
  showQuestionNumbers: "off",
  pageNextText: "Forward",
  completeText: "Submit",
  showPrevButton: false,
  firstPageIsStarted: true,
  startSurveyText: "Take the Survey",
  completedHtml: "Thank you for your feedback!",
  showPreviewBeforeComplete: "showAnsweredQuestions"
};