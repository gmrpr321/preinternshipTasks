const questions = [
    {
      question: "What is the capital of France?",
      options: ["Madrid", "Berlin", "Paris", "Rome"],
      answer: "Paris"
    },
    {
      question: "Which planet is known as the Red Planet?",
      options: ["Venus", "Mars", "Jupiter", "Saturn"],
      answer: "Mars"
    },
    {
      question: "What language is used for web apps?",
      options: ["Python", "Java", "PHP", "JavaScript"],
      answer: "JavaScript"
    }
  ];
  
  let currentQuestion = 0;
  let score = 0;
  
  const questionEl = document.getElementById("question");
  const optionsEl = document.getElementById("options");
  const nextBtn = document.getElementById("nextBtn");
  const resultEl = document.getElementById("result");
  const scoreEl = document.getElementById("score");
  
  function loadQuestion() {
    const q = questions[currentQuestion];
    questionEl.textContent = q.question;
    optionsEl.innerHTML = "";
  
    q.options.forEach(option => {
      const li = document.createElement("li");
      li.textContent = option;
      li.addEventListener("click", () => selectOption(li, q.answer));
      optionsEl.appendChild(li);
    });
  
    nextBtn.disabled = true;
  }
  
  function selectOption(selected, correctAnswer) {
    const allOptions = optionsEl.querySelectorAll("li");
    allOptions.forEach(opt => opt.style.pointerEvents = "none");
  
    if (selected.textContent === correctAnswer) {
      selected.style.background = "#b6f5b6";
      score++;
    } else {
      selected.style.background = "#f5b6b6";
    }
  
    nextBtn.disabled = false;
  }
  
  nextBtn.addEventListener("click", () => {
    currentQuestion++;
    if (currentQuestion < questions.length) {
      loadQuestion();
    } else {
      showResult();
    }
  });
  
  function showResult() {
    document.getElementById("quiz-box").classList.add("hidden");
    resultEl.classList.remove("hidden");
    scoreEl.textContent = `You scored ${score} out of ${questions.length}`;
  }
  
  loadQuestion();
  