window.BlazorApp = {
	autoScrollWindow: () => {
		if (window.innerHeight + window.scrollY < document.body.offsetHeight) {
			window.scrollTo(0, document.body.scrollHeight);
		}
	},
	alertErrorDelete: () => {
		window.alert("Delete item failed");
	},
	logDataJson: (data) => {
		console.log(JSON.parse(data));
	}
}