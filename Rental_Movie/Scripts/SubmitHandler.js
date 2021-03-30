function query() {
	var vm = {
		movieIds: []
	};
	var customers = new Bloodhound({
		datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
		queryTokenizer: Bloodhound.tokenizers.whitespace,
		remote: {
			url: '/api/customers?query=%QUERY ',
			wildcard: '%QUERY'
		}
	});

	$('#customer').typeahead({
		minLength: 3,
		highlight: true
	}, {
		name: 'customers',
		display: 'name',
		source: customers
	}).on("typeahead:select", function (e, customer) {
		vm.customerId = customer.id;
	});
};