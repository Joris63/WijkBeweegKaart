import _ from "lodash";
import { useEffect, useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import LevelButton from "./LevelButton";

const LevelSelector = ({ survey, loadSurvey = () => {} }) => {
  const [levels, setLevels] = useState([]);
  const [loading, setLoading] = useState(true);

  const navigate = useNavigate();

  function FormatLevels() {
    // get all survey levels
    let allLevels = survey
      .filter((page, i) => i > 0)
      .map((page, i) => ({
        nr: i,
        id: page.id,
        title: page.title ? page.title : `level ${i + 1}`,
        reward: 100,
        complete: false,
        locked: i > 0,
        custom: false,
      }));

    console.log(survey);

    // add custom levels
    allLevels.push({
      id: "create-park",
      title: "Eigen park",
      reward: 150,
      complete: true,
      to: "/map",
      custom: true,
    });

    allLevels.push({
      id: "rate-park",
      title: "Beoordeel park",
      reward: 55,
      complete: true,
      to: "/rate",
      custom: true,
    });

    setLevels(allLevels);
  }

  useEffect(() => {
    setLoading(survey === null || _.isEmpty(survey));

    if (survey !== null) {
      FormatLevels();
    }
  }, [survey]);

  return (
    <div className="level_selector">
      <div className="level_selector_header">
        <div className="level_selector_header_welcome">Welkom Joris</div>
        <div className="level_selector_header_points">
          100<i className="fa-duotone fa-coins"></i>
        </div>
      </div>
      {loading ? (
        <div className="container" style={{ height: "70%" }}>
          <div className="bar"></div>
        </div>
      ) : (
        <div className="level_wrapper">
          <div className="level_container">
            {levels
              .filter((lvl) => lvl.custom && lvl.complete)
              .map((lvl) => (
                <LevelButton
                  key={`lvl-button-${lvl.id}`}
                  title={lvl.title}
                  onClick={() => navigate(lvl.to)}
                />
              ))}
          </div>
          <h3 className="level_selector_title">Selecteer level</h3>
          <div className="level_container">
            {levels
              .filter((lvl) => lvl.custom && !lvl.complete)
              .map((lvl) => (
                <LevelButton
                  key={`lvl-button-${lvl.id}`}
                  title={lvl.title}
                  reward={lvl.reward}
                  onClick={() => navigate(lvl.to)}
                />
              ))}
          </div>
          <div className="level_container">
            {levels
              .filter((lvl) => !lvl.complete && !lvl.locked && !lvl.custom)
              .map((lvl) => (
                <LevelButton
                  key={`lvl-button-${lvl.id}`}
                  title={lvl.title}
                  reward={lvl.reward}
                  locked={lvl.locked}
                  complete={lvl.complete}
                  onClick={() => loadSurvey(lvl.id)}
                />
              ))}
          </div>
          <div className="level_container small">
            {levels
              .filter((lvl) => (lvl.complete || lvl.locked) && !lvl.custom)
              .sort((a, b) => {
                if (a.locked && b.complete) return -1;

                if (a.complete && b.locked) return 1;

                return 0;
              })
              .map((lvl) => (
                <LevelButton
                  key={`lvl-button-${lvl.id}`}
                  title={lvl.title}
                  reward={lvl.reward}
                  locked={lvl.locked}
                  complete={lvl.complete}
                  small
                  onClick={() => loadSurvey(lvl.id)}
                />
              ))}
          </div>
        </div>
      )}
    </div>
  );
};

export default LevelSelector;
