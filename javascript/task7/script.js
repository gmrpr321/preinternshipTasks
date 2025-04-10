 const chat = document.getElementById("chat");
  const input = document.getElementById("userInput");

  const botReplies = [
    "Hello! How can I help?",
    "That's interesting!",
    "Tell me more.",
    "Haha, good one!",
    "I'm just a simulation!",
    "Do you like JavaScript?",
    "CSS makes everything pretty!"
  ];

  function getTime() {
    const now = new Date();
    return now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  }

  function addMessage(text, type) {
    const msg = document.createElement("div");
    msg.className = `chat-message ${type}`;
    msg.innerHTML = `${text}<div class="timestamp">${getTime()}</div>`;
    chat.appendChild(msg);
    chat.scrollTop = chat.scrollHeight;
  }

  function sendMessage() {
    const text = input.value.trim();
    if (text === "") return;
    addMessage(text, "user");
    input.value = "";

    setTimeout(() => {
      const reply = botReplies[Math.floor(Math.random() * botReplies.length)];
      addMessage(reply, "bot");
    }, 1000 + Math.random() * 1000);
  }

  input.addEventListener("keypress", (e) => {
    if (e.key === "Enter") sendMessage();
  });