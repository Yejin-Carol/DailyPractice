<h2> Nomad Vanilla JS Challenge </h2>

<h3> 1st Assignment, 14th April, 2022 </h3>

- Practiced different types of EvenListenres (windows as well!)
- First assignment is not that difficult but it's always good way to practice because it makes me a better programmer!
```js
// <⚠️ DONT DELETE THIS ⚠️>
import "./styles.css";
const colors = ["#1abc9c", "#3498db", "#9b59b6", "#f39c12", "#e74c3c"];
// <⚠️ /DONT DELETE THIS ⚠️>

/*
✅ The text of the title should change when the mouse is on top of it.
✅ The text of the title should change when the mouse is leaves it.
✅ When the window is resized the title should change.
✅ On right click the title should also change.
✅ The colors of the title should come from a color from the colors array.
✅ DO NOT CHANGE .css, or .html files.
✅ ALL function handlers should be INSIDE of "superEventHandler"
*/

const h2 = document.querySelector("h2");
const superEventHandler = {
  handleMouseEnter: function () {
    h2.innerText = "The Mouse is here";
    h2.style.color = "#1abc9c";
  },
  handleMouseLeave: function () {
    h2.innerText = "The Mouse is gone!";
    h2.style.color = "#3498db";
  },
  handleWindowResize: function () {
    h2.innerText = "You just resized!";
    h2.style.color = "#e74c3c";
  },
  handleMouseRightClick: function () {
    h2.innerText = "That was a right click";
    h2.style.color = "#f39c12";
  }
};

h2.addEventListener("mouseenter", superEventHandler.handleMouseEnter);
h2.addEventListener("mouseleave", superEventHandler.handleMouseLeave);
window.addEventListener("resize", superEventHandler.handleWindowResize);
h2.addEventListener("contextmenu", superEventHandler.handleMouseRightClick);
```
