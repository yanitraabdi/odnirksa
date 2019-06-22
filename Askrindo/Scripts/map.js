var lampungmap = document.getElementById("lampung-map"),
	provinceInfo = document.getElementById("provinceInfo"),
	allProvinces = lampungmap.querySelectorAll("g");
	lampungmap.addEventListener("click", function(e){ 
		var province = e.target.parentNode;
		if(e.target.nodeName == "path") {
		for (var i=0; i < allProvinces.length; i++) {
			allProvinces[i].classList.remove("active");
		}
		province.classList.add("active");
		var provinceName = province.querySelector("title").innerHTML,
		provincePara = province.querySelector("desc p");
		provinceInfo.innerHTML = "";
		provinceInfo.insertAdjacentHTML("afterbegin", "<h1>"+provinceName+"</h1><p>"+provincePara.innerHTML+"</p>");
		provinceInfo.classList.add("show");
		}
  })
