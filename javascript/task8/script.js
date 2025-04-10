
const routes = {
  home: `
    <h2>Welcome Home</h2>
    <p>This is the homepage of our single-page application.</p>
  `,
  about: `
    <h2>About Us</h2>
    <p>We are building SPAs using pure JavaScript!</p>
  `,
  contact: `
    <h2>Contact</h2>
    <p>You can reach us at Pradeep@gmail.com.</p>
  `
};

function loadRoute() {
  const hash = location.hash.replace("#", "") || "home";
  const content = routes[hash] || "<h2>404</h2><p>Page not found.</p>";
  document.getElementById("app").innerHTML = content;
}

window.addEventListener("hashchange", loadRoute);
window.addEventListener("load", loadRoute);