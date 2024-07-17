console.log("asdasd");

// document.addEventListener("DOMContentLoaded", function() {
    // Toggle edit mode for input fields
    const editButtons = document.querySelectorAll(".edit-btn");
    const saveButtons = document.querySelectorAll(".save-btn");

    editButtons.forEach(button => {
        button.addEventListener("click", function() {
            const inputField = button.closest(".input-group").querySelector("input, textarea");
            inputField.disabled = false;
            inputField.focus();
            toggleButtons(button);
        });
    });

    saveButtons.forEach(button => {
        button.addEventListener("click", function() {
            const inputField = button.closest(".input-group").querySelector("input, textarea");
            inputField.disabled = true;
            inputField.style.backgroundColor = "#e7f3e7"; // Cambiar color de fondo al guardar
            toggleButtons(button);
        });
    });

    function toggleButtons(button) {
        const editButton = button.closest(".input-group").querySelector(".edit-btn");
        const saveButton = button.closest(".input-group").querySelector(".save-btn");
        editButton.classList.toggle("d-none");
        saveButton.classList.toggle("d-none");
    }
// });

// Function to add new personal data fields
function addPersonalData() {

    console.log("persoalData");
    const container = document.getElementById("personalInformationContainer");
    const newGroup = document.createElement("div");
    newGroup.className = "personal-Information-group border p-5";

    newGroup.innerHTML = `
        <div class="form-group input-group">
            <input type="text" class="form-control" name="newPersonalData" placeholder="Nuevo Dato" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
    `;

    container.appendChild(newGroup);

    // Reinitialize event listeners for new elements
    reinitializeEventListeners(newGroup);
}

// Function to add new professional experience fields
function addExperience() {
    const container = document.getElementById("professionalExperienceContainer");
    const newGroup = document.createElement("div");
    newGroup.className = "experience-group border p-5 mb-3";

    newGroup.innerHTML = `
        <div class="form-group input-group">
            <input type="text" class="form-control" name="experience[].company" placeholder="Compañía" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
        <div class="form-group input-group">
            <input type="text" class="form-control" name="experience[].position" placeholder="Cargo" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
        <div class="form-group input-group">
            <input type="date" class="form-control" name="experience[].startDate" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
        <div class="form-group input-group">
            <input type="date" class="form-control" name="experience[].endDate" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
        <div class="form-group description-container">
            <label for="description">Descripción</label>
            <textarea class="form-control" name="experience[].description" rows="3" disabled></textarea>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
    `;

    container.appendChild(newGroup);

    // Reinitialize event listeners for new elements
    reinitializeEventListeners(newGroup);
}

// Function to add new education fields
function addEducation() {
    const container = document.getElementById("educationContainer");
    const newGroup = document.createElement("div");
    newGroup.className = "education-group border p-5 mb-3";

    newGroup.innerHTML = `
        <div class="form-group input-group">
            <input type="text" class="form-control" name="education[].institution" placeholder="Institución" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
        <div class="form-group input-group">
            <input type="text" class="form-control" name="education[].degree" placeholder="Título" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
        <div class="form-group input-group">
            <input type="date" class="form-control" name="education[].startDate" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
        <div class="form-group input-group">
            <input type="date" class="form-control" name="education[].endDate" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
        <div class="form-group description-container">
            <label for="description">Descripción</label>
            <textarea class="form-control" name="education[].description" rows="3" disabled></textarea>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
    `;

    container.appendChild(newGroup);

    // Reinitialize event listeners for new elements
    reinitializeEventListeners(newGroup);
}

// Function to add new competency fields
function addCompetency() {
    const container = document.getElementById("competencyContainer");
    const newGroup = document.createElement("div");
    newGroup.className = "competency-group border p-5 mb-3";

    newGroup.innerHTML = `
        <div class="form-group input-group">
            <input type="text" class="form-control" name="competency[]" placeholder="Competencia" disabled>
            <div class="input-group-append">
                <span class="input-group-text edit-btn"><i class="fas fa-edit"></i></span>
                <span class="input-group-text save-btn d-none"><i class="fas fa-save"></i></span>
            </div>
        </div>
    `;

    container.appendChild(newGroup);

    // Reinitialize event listeners for new elements
    reinitializeEventListeners(newGroup);
}

// Reinitialize event listeners for new elements
function reinitializeEventListeners(container) {
    const editButtons = container.querySelectorAll(".edit-btn");
    const saveButtons = container.querySelectorAll(".save-btn");

    editButtons.forEach(button => {
        button.addEventListener("click", function() {
            const inputField = button.closest(".input-group").querySelector("input, textarea");
            inputField.disabled = false;
            inputField.focus();
            toggleButtons(button);
        });
    });

    saveButtons.forEach(button => {
        button.addEventListener("click", function() {
            const inputField = button.closest(".input-group").querySelector("input, textarea");
            inputField.disabled = true;
            inputField.style.backgroundColor = "#e7f3e7"; // Cambiar color de fondo al guardar
            toggleButtons(button);
        });
    });

    function toggleButtons(button) {
        const editButton = button.closest(".input-group").querySelector(".edit-btn");
        const saveButton = button.closest(".input-group").querySelector(".save-btn");
        editButton.classList.toggle("d-none");
        saveButton.classList.toggle("d-none");
    }
}

console.log("asdasdas");