import LevelButton from "./LevelButton";

const levels = [
  {
    id: 1,
    title: "Creer jouw account",
    reward: 100,
    complete: true,
    locked: false,
  },
  {
    id: 2,
    title: "Link jouw email",
    reward: 50,
    complete: false,
    locked: false,
  },
  {
    id: 3,
    title: "Richt je eigen sportpark in",
    reward: 150,
    complete: false,
    locked: false,
  },
  {
    id: 4,
    title: "Waardeer anderen sportparken en daarna doe dit",
    reward: 100,
    complete: false,
    locked: true,
  },
];

const LevelSelector = () => {
  return (
    <div className="level_selector">
      <div className="level_selector_header">
        <div className="level_selector_header_welcome">Welkom Joris</div>
        <div className="level_selector_header_points">
          100<i className="fa-duotone fa-coins"></i>
        </div>
      </div>
      <h3 className="level_selector_title">Selecteer level</h3>
      <div className="level_container">
        {levels
          .filter((lvl) => !lvl.complete && !lvl.locked)
          .map((lvl) => (
            <LevelButton
              key={`lvl-button-${lvl.id}`}
              title={lvl.title}
              reward={lvl.reward}
              locked={lvl.locked}
              complete={lvl.complete}
            />
          ))}
      </div>
      <div className="level_container small">
        {levels
          .filter((lvl) => lvl.complete || lvl.locked)
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
            />
          ))}
      </div>
    </div>
  );
};

export default LevelSelector;
