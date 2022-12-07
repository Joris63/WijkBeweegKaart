const clamp = (number, min, max) => {
  return Math.min(Math.max(number, min), max);
};

const ProgressBar = ({ progress = 0.1, percentage }) => {
  return (
    <div
      className="progress_bar"
      style={{ marginBottom: percentage ? 24 : null }}
    >
      <span style={{ width: `${clamp(progress * 100, 0, 100)}%` }} />
      {percentage && (
        <div className="percentage">{Math.round(progress * 100)}%</div>
      )}
    </div>
  );
};

export default ProgressBar;
