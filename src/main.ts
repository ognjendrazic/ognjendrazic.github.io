import './style.css';

const lines = document.querySelectorAll<HTMLElement>('.ln');
const reduceMotion = matchMedia('(prefers-reduced-motion: reduce)').matches;

lines.forEach((el, i) => {
  if (reduceMotion) el.classList.add('on');
  else setTimeout(() => el.classList.add('on'), 250 + i * 380);
});
