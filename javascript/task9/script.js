const content = document.getElementById("content");
const loader = document.getElementById("loader");
let page = 1;
let isLoading = false;
let imgCt =  0;
function getDummyData(pageNumber) {
  // Simulate async data fetch with dummy content
  return new Promise((resolve) => {
    setTimeout(() => {
      const items = [];
      for (let i = 1; i <= 10; i++) {
        items.push(``);
      }
      resolve(items);
    }, 1000); // Simulate network delay
  });
}

async function loadMoreContent() {
  if (isLoading) return;
  isLoading = true;
  loader.style.display = "block";
  
  const data = await getDummyData(page++);
  data.forEach(text => {
    const div = document.createElement("div");
    const img = document.createElement("img");
    img.src=`https://picsum.photos/id/${imgCt}/400/300`
    imgCt++;
    div.className = "item";
    div.textContent = text;
    div.appendChild(img);
    content.appendChild(div);
  });

  loader.style.display = "none";
  isLoading = false;
}

function handleScroll() {
  const { scrollTop, scrollHeight, clientHeight } = document.documentElement;
  if (scrollTop + clientHeight >= scrollHeight - 10) {
    loadMoreContent();
  }
}

window.addEventListener("scroll", handleScroll);
window.addEventListener("load", loadMoreContent); // Initial load