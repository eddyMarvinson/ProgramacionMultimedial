var camera, scene, renderer;
var cameraControls;
var clock = new THREE.Clock();
var ambientLight, light;

function init() {
	var canvasWidth = window.innerWidth * 0.9;
	var canvasHeight = window.innerHeight * 0.9;

	// CAMERA
	camera = new THREE.PerspectiveCamera( 45, window.innerWidth / window.innerHeight, 1, 80000 );
	camera.position.set(-1,1,3);
	camera.lookAt(0,0,0);

	// LIGHTS
	light = new THREE.DirectionalLight( 0xFFFFFF, 0.7 );
	light.position.set( 1, 1, 1 );
	light.target.position.set(0, 0, 0);
	light.target.updateMatrixWorld()

	var ambientLight = new THREE.AmbientLight( 0x111111 );

	// RENDERER
	renderer = new THREE.WebGLRenderer( { antialias: true } );
	renderer.setSize( canvasWidth, canvasHeight );
	renderer.setClearColor( 0xAAAAAA, 1.0 );

	renderer.gammaInput = true;
	renderer.gammaOutput = true;

	// Add to DOM
	var container = document.getElementById('container');
	container.appendChild( renderer.domElement );

	// CONTROLS
	cameraControls = new THREE.OrbitControls( camera, renderer.domElement );
	cameraControls.target.set(0, 0, 0);

	// SCENE
	scene = new THREE.Scene();
	scene.add( light );
	scene.add( ambientLight );
	
	// Add arbol
	scene.add( generar_tronco(0.8, 0.2, 0.05, 0x6C3B2A) );
	scene.add( generar_nivel_tipo1(0.5, 0.3, 0.3, 0.2, 0x008F39) );
	scene.add( generar_nivel_tipo1(0.4, 0.35, 0.3, 0.2, 0x009F40) );
	scene.add( generar_nivel_tipo1(0.6, 0.4, 0.25, 0.15, 0x008F39) );
	scene.add( generar_nivel_tipo1(0.5, 0.45, 0.25, 0.15, 0x009F40) );
	scene.add( generar_nivel_tipo1(0.7, 0.5, 0.2, 0.1, 0x008F39) );
	scene.add( generar_nivel_tipo1(0.6, 0.55, 0.2, 0.1, 0x009F40) );
	scene.add( generar_nivel_tipo1(0.8, 0.6, 0.15, 0.05, 0x008F39) );
	scene.add( generar_nivel_tipo1(0.7, 0.65, 0.15, 0.05, 0x009F40) );
	scene.add( generar_nivel_tipo1(0.9, 0.7, 0.1, 0.02, 0x008F39) );
	scene.add( generar_nivel_tipo1(0.8, 0.75, 0.1, 0.02, 0x009F40) );
	
	// Add adornos
	var geometry = new THREE.SphereGeometry(0.02, 0.05, 0.05);
	var material = new THREE.MeshNormalMaterial();
	
	var alt = 0.3;
	var a = 0.3;
	var b = 0.33;
	for (var i = 0; i < 6; i++) {
		var cube0 = new THREE.Mesh(geometry, material);
		cube0.position.set( a , alt, 0 );
		scene.add(cube0);
		var cube1 = new THREE.Mesh(geometry, material);
		cube1.position.set( -a , alt, 0 ) ;
		scene.add(cube1);
		var cube2 = new THREE.Mesh(geometry, material);
		cube2.position.set( 0 , alt, -a ) ;
		scene.add(cube2);
		var cube3 = new THREE.Mesh(geometry, material);
		cube3.position.set( 0 , alt, a ) ;
		scene.add(cube3);
		alt += 0.09;
		a -= 0.05
	}
}

// Funcion genera tronco del arbol
function generar_tronco(pico, base, lado, _color){
	var tronco = new THREE.Geometry();
	tronco.vertices.push( new THREE.Vector3( 0 , pico , 0 ) );
	tronco.vertices.push( new THREE.Vector3( lado , base , 0 ) );
	tronco.vertices.push( new THREE.Vector3( -lado , base , 0 ) );
	tronco.vertices.push( new THREE.Vector3( 0 , base , -lado ) );
	tronco.vertices.push( new THREE.Vector3( 0 , base , lado ) );
	tronco.faces.push( new THREE.Face3( 0, 1, 3 ) );
	tronco.faces.push( new THREE.Face3( 0, 3, 1 ) );
	tronco.faces.push( new THREE.Face3( 0, 1, 4 ) );
	tronco.faces.push( new THREE.Face3( 0, 4, 1 ) );
	tronco.faces.push( new THREE.Face3( 0, 3, 2 ) );
	tronco.faces.push( new THREE.Face3( 0, 2, 3 ) );
	tronco.faces.push( new THREE.Face3( 0, 2, 4 ) );
	tronco.faces.push( new THREE.Face3( 0, 4, 2 ) );
    var material_tronco = new THREE.MeshBasicMaterial( { color: _color } );
    return (new THREE.Mesh (tronco, material_tronco));
}

// Funcion genera hexagonos
function generar_nivel_tipo1(pico, base, a, b, _color){
	var nivel1 = new THREE.Geometry();
	nivel1.vertices.push( new THREE.Vector3( 0 , pico, 0 ) );
	nivel1.vertices.push( new THREE.Vector3( a , base, 0 ) );
	nivel1.vertices.push( new THREE.Vector3( -a , base, 0 ) );
	nivel1.vertices.push( new THREE.Vector3( 0 , base, -a ) );
	nivel1.vertices.push( new THREE.Vector3( 0 , base, a ) );
	nivel1.vertices.push( new THREE.Vector3( b , base, b ) );
	nivel1.vertices.push( new THREE.Vector3( -b , base, b ) );
	nivel1.vertices.push( new THREE.Vector3( -b , base, -b ) );
	nivel1.vertices.push( new THREE.Vector3( b , base, -b ) );
	nivel1.faces.push( new THREE.Face3( 0, 1, 5 ) );
	nivel1.faces.push( new THREE.Face3( 0, 5, 1 ) );
	nivel1.faces.push( new THREE.Face3( 0, 6, 2 ) );
	nivel1.faces.push( new THREE.Face3( 0, 2, 6 ) );
	nivel1.faces.push( new THREE.Face3( 0, 2, 7 ) );
	nivel1.faces.push( new THREE.Face3( 0, 7, 2 ) );
	nivel1.faces.push( new THREE.Face3( 0, 3, 7 ) );
	nivel1.faces.push( new THREE.Face3( 0, 7, 3 ) );
	nivel1.faces.push( new THREE.Face3( 0, 4, 5 ) );
	nivel1.faces.push( new THREE.Face3( 0, 5, 4 ) );
	nivel1.faces.push( new THREE.Face3( 0, 4, 6 ) );
	nivel1.faces.push( new THREE.Face3( 0, 6, 4 ) );
	nivel1.faces.push( new THREE.Face3( 0, 8, 3 ) );
	nivel1.faces.push( new THREE.Face3( 0, 3, 8 ) );
	nivel1.faces.push( new THREE.Face3( 0, 8, 1 ) );
	nivel1.faces.push( new THREE.Face3( 0, 1, 8 ) );
	var material_nivel1 = new THREE.MeshBasicMaterial( { color: _color } );
    return (new THREE.Mesh (nivel1, material_nivel1));
}

function animate() {
	window.requestAnimationFrame( animate );
	render();
}

function render() {
	var delta = clock.getDelta();
	cameraControls.update(delta);
	renderer.render( scene, camera );
}

try {
	init();
	animate();
} catch(e) {
	var errorReport = "Your program encountered an unrecoverable error, can not draw on canvas. Error was:<br/><br/>";
	$('#container').append(errorReport+e);
}
