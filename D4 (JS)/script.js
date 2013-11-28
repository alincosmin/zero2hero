var angajati;
if (localStorage.angajati == undefined || localStorage.angajati.length < 10)
	{
	localStorage.angajati = '';
	angajati = [{
		nume:'',
		prenume:'',
		varsta:0,
		data:'',
		departament:'',
		link:'',
		poza:''
	}];}
else angajati = JSON.parse(localStorage.angajati);

function new_ang(){
	var id = angajati.length;
	if (angajati[id-1].nume.length == 0)
		edit_ang(id-1);
	else {
	angajati.push({nume:'',prenume:'',varsta:0,data:'',departament:'',link:'',poza:''});
	populareTabel();
	edit_ang(id);
	}
}

function update_size(){
	var btn = document.getElementById('local_size');
	btn.value = localStorage.angajati.length + 'B stored';
}

function gen_rand_editare(angajat,id){
	var rand = '<tr>'
	+ '<td><input type="text" size="10" value="'+angajat.nume+'"/></td>'
	+ '<td><input type="text" size="10" value="'+angajat.prenume+'"/></td>'
	+ '<td><input type="number" size="2" value="'+angajat.varsta+'"/></td>'
	+ '<td><input type="text" value="'+angajat.data+'"/></td>'
	+ '<td><input type="text" size="10" value="'+angajat.departament+'"/></td>'
	+ '<td><input type="url" size="10" value="'+angajat.link+'"/></td>'
	+ '<td><input type="file" size="10" value="'+angajat.poza+'"/></td>'
	+ '<td class="cel_but"><input type="button" value="Save" onclick="save_ang('+id+')" />&nbsp;&nbsp;&nbsp;<input type="button" value="Cancel" onclick="revert_ang('+id+')" /></td>'
	+'</tr>'
	
	return rand;
}

function edit_ang(id){
	var tbody = document.getElementById('lista');
	tbody.childNodes[id].innerHTML = gen_rand_editare(angajati[id],id);	
}

function save_ang(id){
	var tbody = document.getElementById('lista');
	var lista_campuri = tbody.childNodes[id].childNodes;
	angajati[id].nume = lista_campuri[0].firstChild.value;
	angajati[id].prenume = lista_campuri[1].firstChild.value;
	angajati[id].varsta = lista_campuri[2].firstChild.value;
	angajati[id].data = lista_campuri[3].firstChild.value;
	angajati[id].departament = lista_campuri[4].firstChild.value;
	angajati[id].link = lista_campuri[5].firstChild.value;
	angajati[id].poza = lista_campuri[6].firstChild.value;
	if (angajati[id].nume.length != 0)
		tbody.childNodes[id].innerHTML = gen_rand(angajati[id],id);
	localStorage.angajati = JSON.stringify(angajati);
	update_size();
}

function delete_ang(id,x){
	if (id == 0 && angajati[id].nume.length > 0)
			angajati = [{
			nume:'',
			prenume:'',
			varsta:0,
			data:'',
			departament:'',
			link:'',
			poza:''
				}]
	else if (id == 0)
		{
			alert("Can't delete the only element!");
			return;
		}
	if (x == 1)
		angajati.splice(id,1);
	else if (confirm('Are you sure you want to remove ' + angajati[id].nume + ' ' + angajati[id].prenume + '?'))
		angajati.splice(id,1);
	localStorage.angajati = JSON.stringify(angajati);
	update_size();
	populareTabel();
	
}

function gen_rand(angajat,id){
	var rand = '<tr>'
	+ '<td><span>'+angajat.nume+'</span></td>'
	+ '<td><span>'+angajat.prenume+'</span></td>'
	+ '<td><span>'+angajat.varsta+'</span></td>'
	+ '<td><span>'+angajat.data+'</span></td>'
	+ '<td><span>'+angajat.departament+'</span></td>'
	+ '<td><a href="'+angajat.link+'">Link</a></td>'
	+ '<td><img src="'+angajat.poza+'" />'
	+ '<td class="cel_but"><input type="button" value="Edit" onclick="edit_ang('+id+')" />&nbsp;&nbsp;&nbsp;<input type="button" value="Delete" onclick="delete_ang('+id+')" /></td>'
	+'</tr>'
	
	return rand;
}

function revert_ang(id){
	if (angajati[id].nume.length ==0)
		delete_ang(id,1);
	else {
	var tbody = document.getElementById('lista');
	tbody.childNodes[id].innerHTML = gen_rand(angajati[id],id);
	}
}

function tbody_angajati(lista){
	var corp='';
	for(var index = 0; index < lista.length; index++){
		var ang = lista[index];
		corp+=gen_rand(ang,index);
	}
	return corp;
}

function populareTabel(){
	var tbody = document.getElementById('lista');
	tbody.innerHTML = tbody_angajati(angajati) + '<tr><td colspan="7"></td><td><input type="button" onclick="new_ang()" value="Add new" /></td></tr>';
}

function empty_local(){
	if (confirm('Are you sure you want to delete local data?'))
		localStorage.angajati = '';
}