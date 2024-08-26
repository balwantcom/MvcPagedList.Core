


 $(document).ready(function () {
			$('#dtshow').DataTable( {      
				"searching": false, // Hide Searching textbox
				"paging": true,  // Show pagging number
				"info": true,  // hide showing entries   
				"filter":false,    //hide Search bar    
				"lengthChange":false , // hide number top filter
				"ordering": false,
		
				language: {
			paginate: {
				first: 'First',
					last: 'Last',
					next: 'Next',
					previous: 'Previous'
			}}
		} );
      });