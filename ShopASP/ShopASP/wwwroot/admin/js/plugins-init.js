// INITIALIZATION OF NAVBAR VERTICAL ASIDE
// =======================================================
new HSSideNav(".js-navbar-vertical-aside").init()

// INITIALIZATION OF BOOTSTRAP DROPDOWN
// =======================================================
HSBsDropdown.init()

// INITIALIZATION OF FORM SEARCH
// =======================================================
new HSFormSearch(".js-form-search")

// STYLE SWITCHER
// =======================================================
const $dropdownBtn = document.getElementById("selectThemeDropdown") // Dropdowon trigger
const $variants = document.querySelectorAll(
	`[aria-labelledby="selectThemeDropdown"] [data-icon]`,
) // All items of the dropdown

// Function to set active style in the dorpdown menu and set icon for dropdown trigger
const setActiveStyle = function () {
	$variants.forEach(($item) => {
		if (
			$item.getAttribute("data-value") ===
			HSThemeAppearance.getOriginalAppearance()
		) {
			$dropdownBtn.innerHTML = `<i class="${$item.getAttribute(
				"data-icon",
			)}" />`
			return $item.classList.add("active")
		}

		$item.classList.remove("active")
	})
}

// Add a click event to all items of the dropdown to set the style
$variants.forEach(function ($item) {
	$item.addEventListener("click", function () {
		HSThemeAppearance.setAppearance($item.getAttribute("data-value"))
	})
})

// Call the setActiveStyle on load page
setActiveStyle()

// Add event listener on change style to call the setActiveStyle function
window.addEventListener("on-hs-appearance-change", function () {
	setActiveStyle()
})

// INITIALIZATION OF DATATABLES
// =======================================================
HSCore.components.HSDatatables.init(".js-datatable", {
	select: {
		style: "multi",
		selector: 'td:first-child input[type="checkbox"]',
		classMap: {
			checkAll: "#datatableWithCheckboxSelectAll",
			counter: "#datatableWithCheckboxSelectCounter",
			counterInfo: "#datatableWithCheckboxSelectCounterInfo",
		},
	},
})
try {
	const datatableSortingColumn =
		HSCore.components.HSDatatables.getItem("columnSorting")

	document
		.getElementById("toggleColumn_position")
		.addEventListener("change", function (e) {
			datatableSortingColumn.columns(1).visible(e.target.checked)
		})

	document
		.getElementById("toggleColumn_country")
		.addEventListener("change", function (e) {
			datatableSortingColumn.columns(2).visible(e.target.checked)
		})

	document
		.getElementById("toggleColumn_status")
		.addEventListener("change", function (e) {
			datatableSortingColumn.columns(3).visible(e.target.checked)
		})
} catch {}

// INITIALIZATION OF FILE ATTACH
// =======================================================
new HSFileAttach(".js-file-attach")

// INITIALIZATION OF STEP FORM
// =======================================================
new HSStepForm(".js-step-form", {
	finish: () => {
		document.getElementById("addUserStepFormProgress").style.display =
			"none"
		document.getElementById("addUserStepProfile").style.display = "none"
		document.getElementById("addUserStepBillingAddress").style.display =
			"none"
		document.getElementById("addUserStepConfirmation").style.display =
			"none"
		document.getElementById("successMessageContent").style.display = "block"
		scrollToTop("#header")
		const formContainer = document.getElementById("formContainer")
	},
	onNextStep: function () {
		scrollToTop()
	},
	onPrevStep: function () {
		scrollToTop()
	},
})

function scrollToTop(el = ".js-step-form") {
	el = document.querySelector(el)
	window.scrollTo({
		top: el.getBoundingClientRect().top + window.scrollY - 30,
		left: 0,
		behavior: "smooth",
	})
}

// INITIALIZATION OF ADD FIELD
// =======================================================
new HSAddField(".js-add-field", {
	addedField: (field) => {
		HSCore.components.HSTomSelect.init(
			field.querySelector(".js-select-dynamic"),
		)
		HSCore.components.HSMask.init(field.querySelector(".js-input-mask"))
	},
})

// INITIALIZATION OF SELECT
// =======================================================
HSCore.components.HSTomSelect.init(".js-select", {
	render: {
		option: function (data, escape) {
			return data.optionTemplate || `<div>${data.text}</div>>`
		},
		item: function (data, escape) {
			return data.optionTemplate || `<div>${data.text}</div>>`
		},
	},
})

// INITIALIZATION OF INPUT MASK
// =======================================================
HSCore.components.HSMask.init(".js-input-mask")
// INITIALIZATION OF TOGGLE PASSWORD
// =======================================================
new HSTogglePassword(".js-toggle-password")