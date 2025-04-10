const products = [
    { id: 1, name: "Cliff", price: 15.99, image: "https://picsum.photos/id/1015/200/150" },
    { id: 2, name: "Mountain ", price: 49.99, image: "https://picsum.photos/id/1018/200/150" },
    { id: 3, name: "Boat", price: 29.99, image: "https://picsum.photos/id/1011/200/150" },
    { id: 4, name: "Deer", price: 19.99, image: "https://picsum.photos/id/1003/200/150" },
    { id: 5, name: "Doggie", price: 12.99, image: "https://picsum.photos/id/1025/200/150" },
  ];
  
  let cart = JSON.parse(localStorage.getItem("cart")) || [];
  
  const productContainer = document.getElementById("products");
  const cartContainer = document.getElementById("cart-items");
  const cartTotal = document.getElementById("cart-total");
  const cartCount = document.getElementById("cart-count");
  const searchInput = document.getElementById("search");
  
  function renderProducts(list) {
    productContainer.innerHTML = "";
    list.forEach((product) => {
      const div = document.createElement("div");
      div.className = "product";
      div.innerHTML = `
        <img src="${product.image}" alt="${product.name}" />
        <h3>${product.name}</h3>
        <p>$${product.price.toFixed(2)}</p>
        <button onclick="addToCart(${product.id})">Add to Cart</button>
      `;
      productContainer.appendChild(div);
    });
  }
  
  function renderCart() {
    cartContainer.innerHTML = "";
    let total = 0;
    cart.forEach((item) => {
      const product = products.find((p) => p.id === item.id);
      total += product.price * item.qty;
      const div = document.createElement("div");
      div.innerHTML = `
        ${product.name} - $${product.price} x 
        <input type="number" value="${item.qty}" min="1" onchange="updateQty(${item.id}, this.value)" />
        <button onclick="removeFromCart(${item.id})">❌</button>
      `;
      cartContainer.appendChild(div);
    });
    cartTotal.textContent = total.toFixed(2);
    cartCount.textContent = cart.reduce((acc, item) => acc + item.qty, 0);
    localStorage.setItem("cart", JSON.stringify(cart));
  }
  
  window.addToCart = (id) => {
    const item = cart.find((p) => p.id === id);
    if (item) {
      item.qty++;
    } else {
      cart.push({ id, qty: 1 });
    }
    renderCart();
  };
  
  window.removeFromCart = (id) => {
    cart = cart.filter((item) => item.id !== id);
    renderCart();
  };
  
  window.clearCart = () => {
    cart = [];
    renderCart();
  };
  
  window.updateQty = (id, qty) => {
    const item = cart.find((p) => p.id === id);
    if (item) {
      item.qty = parseInt(qty);
    }
    renderCart();
  };
  
  searchInput.addEventListener("input", () => {
    const keyword = searchInput.value.toLowerCase();
    const filtered = products.filter((p) => p.name.toLowerCase().includes(keyword));
    renderProducts(filtered);
  });
  
  renderProducts(products);
  renderCart();
  