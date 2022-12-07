const clamp = (number, min, max) => {
  return Math.min(Math.max(number, min), max);
};

const ProgressBar = ({ progress = 0.1, percentage }) => {
  const clampedProgress = clamp(progress * 100, 0, 100);

  return (
    <div
      className="progress_bar"
      style={{ marginBottom: percentage ? 24 : null }}
    >
      <span style={{ width: `${clampedProgress}%` }} />
      {percentage && (
        <div className="percentage">{Math.round(clampedProgress)}%</div>
      )}
    </div>
  );
};

export default ProgressBar;
