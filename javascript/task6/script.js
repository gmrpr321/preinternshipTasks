let dragSrcEl = null;

function handleDragStart(e) {
  dragSrcEl = this;
  this.style.opacity = '0.4';
}

function handleDragOver(e) {
  e.preventDefault();
  
}

function handleDragEnter(e) {
  this.classList.add('over');

}

function handleDragLeave(e) {
  this.classList.remove('over');
  
}

function handleDrop(e) {
  e.stopPropagation();

  if (dragSrcEl !== this) {
      const parent = this.parentNode;
      const src = dragSrcEl;
      const target = this;
      
      const srcClone = src.cloneNode(true);
      const targetClone = target.cloneNode(true);
      
      parent.replaceChild(srcClone, target);
      parent.replaceChild(targetClone, src);
      srcClone.style.opacity=1;

    applyDragEvents();
  }
  return false;
}

function handleDragEnd() {
  this.style.opacity = '1';
  document.querySelectorAll('#draggable-list li').forEach(item => {
    item.classList.remove('over');
  });
}

function applyDragEvents() {
  const items = document.querySelectorAll('#draggable-list li');
  items.forEach(item => {
    item.addEventListener('dragstart', handleDragStart);
    item.addEventListener('dragover', handleDragOver);
    item.addEventListener('dragenter', handleDragEnter);
    item.addEventListener('dragleave', handleDragLeave);
    item.addEventListener('drop', handleDrop);
    item.addEventListener('dragend', handleDragEnd);
  });
}


applyDragEvents();