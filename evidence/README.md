
# Evidencia de Funcionamiento – Bootcamp

Algunas evidencias visuales del correcto despliegue y funcionamiento de la **API Bootcamp ** junto con los servicios de observabilidad utilizados durante la prueba.

Las capturas incluyen comandos ejecutados en consola y verificaciones visuales desde el navegador.


---

## Bootcamp Service (API)

Esta sección muestra la evidencia del despliegue y funcionamiento de la API principal del proyecto.

### 🔹 Servicio corriendo en Minikube
Captura donde se observa el servicio levantado correctamente en el clúster.

![Servicio corriendo en Minikube](bootcampservice/01_corriendo_servicio_minikube.png)

### 🔹 API disponible
Verificación visual desde el navegador confirmando que la API está activa.

![API arriba](bootcampservice/02_api_arriba.png)

### 🔹 Endpoint funcionando
Ejecución de un endpoint (`GET`) que devuelve la lista esperada de datos.

![GET List](bootcampservice/03_getlist.png)

---

## Grafana

Evidencias relacionadas al servicio de **Grafana**, utilizado para visualización de métricas.

### 🔹 Inicio de servicios
Comandos ejecutados en consola para levantar Grafana.

![Iniciando Grafana](grafana/01_iniciando_servicios.png)

### 🔹 Servicio operativo
Acceso exitoso a la interfaz web de Grafana desde el navegador.

![Grafana arriba](grafana/servicio_arriba.png)

---

## Prometheus

Evidencias del servicio **Prometheus**, encargado de la recolección de métricas.

### 🔹 Inicio de servicios
Ejecución de los comandos necesarios para levantar Prometheus.

![Iniciando Prometheus](prometheus/iniciando_servicios.png)

### 🔹 Servicio operativo
Pantalla del navegador mostrando Prometheus funcionando correctamente.

![Prometheus arriba](prometheus/servicio_arriba.png)

---

## Seq (Logs)

Servicio utilizado para la visualización y análisis de logs de la aplicación.

### 🔹 Visualización de logs
Captura del acceso al panel web de Seq mostrando los logs generados por la aplicación.

![Seq logs](seq/02_SEQ.png)


##  CI/CD

Esta sección evidencia el flujo de integración y despliegue continuo (CI/CD) realizado con GitHub Actions, Docker y Helm en Minikube.

### 1️⃣ Configuración del Runner en Windows
![Runner configuración](cicd/01_configuracion_runner_en_windows.png)

### 2️⃣ Runner registrado en GitHub
![Runner en GitHub](cicd/02_runner_equipo_en_github.png)

### 3️⃣ Estado del Pod antes del commit
![Pod antes del commit](cicd/03_descripcion_pod_antes_del_commit_githubaction.png)

### 4️⃣ Commit ejecutándose en Actions
![Commit en Actions](cicd/04_commit_mostrandose_en_actions.png)

### 5️⃣ CI/CD completado con éxito
![CI/CD completado](cicd/05_cicd_completado_con_exito.png)

### 6️⃣ Estado del Pod con el tag aplicado
![Pod con tag](cicd/06_descripcion_del_pod_con_el_tag.png)