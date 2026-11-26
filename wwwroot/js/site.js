// Reveal the terminal lines one by one, like a device printing its boot log.
const lines = document.querySelectorAll('.ln');
const reduceMotion = matchMedia('(prefers-reduced-motion: reduce)').matches;

lines.forEach((el, i) => {
  if (reduceMotion) el.classList.add('on');
  else setTimeout(() => el.classList.add('on'), 250 + i * 380);
});
