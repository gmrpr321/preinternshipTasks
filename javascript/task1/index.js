const taskForm = document.getElementById('taskForm');
const taskInput = document.getElementById('taskInput');
const taskList = document.getElementById('taskList');

let tasks = JSON.parse(localStorage.getItem('tasks')) || [];

function renderTasks() {
  taskList.innerHTML = '';
  tasks.forEach((task, index) => {
    const li = document.createElement('li');
    li.className = task.completed ? 'completed' : '';
    li.innerHTML = `
      <span>${task.text}</span>
      <div>
        <button onclick="toggleTask(${index})">&#10003;</button>
        <button onclick="removeTask(${index})">&#10060;</button>
      </div>
    `;
    taskList.appendChild(li);
  });
}

function addTask(text) {
  tasks.push({ text, completed: false });
  updateStorage();
}

function toggleTask(index) {
  tasks[index].completed = !tasks[index].completed;
  updateStorage();
}

function removeTask(index) {
  tasks.splice(index, 1);
  updateStorage();
}

function updateStorage() {
  localStorage.setItem('tasks', JSON.stringify(tasks));
  renderTasks();
}

taskForm.addEventListener('submit', (e) => {
  e.preventDefault();
  const text = taskInput.value.trim();
  if (text !== '') {
    addTask(text);
    taskInput.value = '';
  }
});

renderTasks();
