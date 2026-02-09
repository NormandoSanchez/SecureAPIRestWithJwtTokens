using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SecureAPIRestWithJwtTokens.Tools;
using SecureAPIRestWithJwtTokens.Models.Entities;
using SecureAPIRestWithJwtTokens.Services;
using SecureAPIRestWithJwtTokens.Constants;

namespace SecureAPIRestWithJwtTokens.DataContexts;

/// <summary>
/// DataContext para la base de datos TrebolDB
/// </summary>
public partial class TrebolDbContext : DbContext
{
    public TrebolDbContext()
    {
    }

    public TrebolDbContext(DbContextOptions<TrebolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticulosErp> ArticulosErps { get; set; }

    public virtual DbSet<ArticulosErpsinonimo> ArticulosErpsinonimos { get; set; }

    public virtual DbSet<ArticulosExclBonif> ArticulosExclBonifs { get; set; }

    public virtual DbSet<ArticulosMod> ArticulosMods { get; set; }

    public virtual DbSet<ArticulosModBidum> ArticulosModBida { get; set; }

    public virtual DbSet<ArticulosModMebidaB> ArticulosModMebidaBs { get; set; }

    public virtual DbSet<ArticulosModMebidum> ArticulosModMebida { get; set; }

    public virtual DbSet<AvisoDocumento> AvisosDocumentos { get; set; }

    public virtual DbSet<AvisoInterno> AvisosInternos { get; set; }

    public virtual DbSet<BajaArticuloErp> BajaArticuloErps { get; set; }

    public virtual DbSet<BajaCliente> BajaClientes { get; set; }

    public virtual DbSet<BajaClientesComentario> BajaClientesComentarios { get; set; }

    public virtual DbSet<BajaClientesCuenta> BajaClientesCuentas { get; set; }

    public virtual DbSet<BajaClientesTarjeta> BajaClientesTarjetas { get; set; }

    public virtual DbSet<BajaCuenta> BajaCuentas { get; set; }

    public virtual DbSet<BajaCuentasBono> BajaCuentasBonos { get; set; }

    public virtual DbSet<BajaCuentasDetalle> BajaCuentasDetalles { get; set; }

    public virtual DbSet<BajaCuentasDetalleArticulo> BajaCuentasDetalleArticulos { get; set; }

    public virtual DbSet<BajaCuentasDetalleHistorico> BajaCuentasDetalleHistoricos { get; set; }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<BtarticuloErp> BtarticuloErps { get; set; }

    public virtual DbSet<CalendarioFestivo> CalendarioFestivos { get; set; }

    public virtual DbSet<CalendarioFestivosDia> CalendarioFestivosDias { get; set; }

    public virtual DbSet<Campania> Campanias { get; set; }

    public virtual DbSet<CampaniasArticulo> CampaniasArticulos { get; set; }

    public virtual DbSet<CampaniasCliente> CampaniasClientes { get; set; }

    public virtual DbSet<CampaniasTarjetasTipo> CampaniasTarjetasTipos { get; set; }

    public virtual DbSet<CanonTrebolDef> CanonTrebolDefs { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<CerrarCondicione> CerrarCondiciones { get; set; }

    public virtual DbSet<ClasificComercialTemp> ClasificComercialTemps { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClientesCalidadDato> ClientesCalidadDatos { get; set; }

    public virtual DbSet<ClientesCambiosErpweb> ClientesCambiosErpwebs { get; set; }

    public virtual DbSet<ClientesComentario> ClientesComentarios { get; set; }

    public virtual DbSet<ClientesDocumentosLopd> ClientesDocumentosLopds { get; set; }

    public virtual DbSet<ClientesErpWeb> ClientesErpWebs { get; set; }

    public virtual DbSet<ClientesTarjeta> ClientesTarjetas { get; set; }

    public virtual DbSet<CodigodLabDel> CodigodLabDels { get; set; }

    public virtual DbSet<CodigosBorrado> CodigosBorrados { get; set; }

    public virtual DbSet<ComunidadAut> ComunidadesAut { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<ConsultaSql> ConsultasSql { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<ContadoresFacTrebol> ContadoresFacTrebols { get; set; }

    public virtual DbSet<ContadoresLotesEnvio> ContadoresLotesEnvios { get; set; }

    public virtual DbSet<ContadoresPnf> ContadoresPnfs { get; set; }

    public virtual DbSet<ConvTiposVia> ConvTiposVias { get; set; }

    public virtual DbSet<ConvUsuvefrel> ConvUsuvefrels { get; set; }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<CuentasBono> CuentasBonos { get; set; }

    public virtual DbSet<CuentasDetalle> CuentasDetalles { get; set; }

    public virtual DbSet<CuentasDetalleArticulo> CuentasDetalleArticulos { get; set; }

    public virtual DbSet<CuentasDetalleHistorico> CuentasDetalleHistoricos { get; set; }

    public virtual DbSet<CuentasDetalleHistoricoAntesRegeneracion> CuentasDetalleHistoricoAntesRegeneracions { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DescripcionArticuloErp> DescripcionArticuloErps { get; set; }

    public virtual DbSet<DescripcionIvaerp> DescripcionIvaerps { get; set; }

    public virtual DbSet<DiferenciaErpfarmatic> DiferenciaErpfarmatics { get; set; }

    public virtual DbSet<Direccion> Direcciones { get; set; }

    public virtual DbSet<DocumentosLopd> DocumentosLopds { get; set; }

    public virtual DbSet<Emedefinicion> Emedefinicions { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EmpleadosDocumento> EmpleadosDocumentos { get; set; }

    public virtual DbSet<EmpleadoUnidadNegocio> EmpleadosUnidadesNegs { get; set; }

    public virtual DbSet<EmpleadoUnidadNegRole> EmpleadosUnidadesNegRoles { get; set; }

    public virtual DbSet<EnviosFormulario> EnviosFormularios { get; set; }

    public virtual DbSet<EnviosFormulariosLinea> EnviosFormulariosLineas { get; set; }

    public virtual DbSet<FacturasTrebol> FacturasTrebols { get; set; }

    public virtual DbSet<FacturasTrebolConcepto> FacturasTrebolConceptos { get; set; }

    public virtual DbSet<FacturasTrebolConceptosUnn> FacturasTrebolConceptosUnns { get; set; }

    public virtual DbSet<FacturasTrebolLinea> FacturasTrebolLineas { get; set; }

    public virtual DbSet<FacturasTrebolLineasBase> FacturasTrebolLineasBases { get; set; }

    public virtual DbSet<FacturasTrebolResumenLin> FacturasTrebolResumenLins { get; set; }

    public virtual DbSet<FacturasTrebolTexto> FacturasTrebolTextos { get; set; }

    public virtual DbSet<FormasPago> FormasPagos { get; set; }

    public virtual DbSet<FormasPagoDia> FormasPagoDias { get; set; }

    public virtual DbSet<Formulario> Formularios { get; set; }

    public virtual DbSet<FormulariosAnulacion> FormulariosAnulacions { get; set; }

    public virtual DbSet<FtpickingOv> FtpickingOvs { get; set; }

    public virtual DbSet<FtpickingOvlinea> FtpickingOvlineas { get; set; }

    public virtual DbSet<FtpickingOvrecepRel> FtpickingOvrecepRels { get; set; }

    public virtual DbSet<Fttraspaso> Fttraspasos { get; set; }

    public virtual DbSet<FttraspasosLinea> FttraspasosLineas { get; set; }

    public virtual DbSet<Generico> Genericos { get; set; }

    public virtual DbSet<GenericosSeleccion> GenericosSeleccions { get; set; }

    public virtual DbSet<GrupoPedido> GrupoPedidos { get; set; }

    public virtual DbSet<GruposLaboratorio> GruposLaboratorios { get; set; }

    public virtual DbSet<GruposLaboratoriosCont> GruposLaboratoriosConts { get; set; }

    public virtual DbSet<GruposLaboratoriosDir> GruposLaboratoriosDirs { get; set; }

    public virtual DbSet<GruposProveedore> GruposProveedores { get; set; }

    public virtual DbSet<GruposProveedoresCalculosPvp> GruposProveedoresCalculosPvps { get; set; }

    public virtual DbSet<GruposProveedoresCont> GruposProveedoresConts { get; set; }

    public virtual DbSet<GruposProveedoresDir> GruposProveedoresDirs { get; set; }

    public virtual DbSet<HiloEjecucione> HiloEjecuciones { get; set; }

    public virtual DbSet<HistoricoTarifa> HistoricoTarifas { get; set; }

    public virtual DbSet<IftarticulosMargenExcl> IftarticulosMargenExcls { get; set; }

    public virtual DbSet<IftextraccionControl> IftextraccionControls { get; set; }

    public virtual DbSet<IftgrupoProceso> IftgrupoProcesos { get; set; }

    public virtual DbSet<IftlogActividad> IftlogActividads { get; set; }

    public virtual DbSet<IftopActualizacionPendiente> IftopActualizacionPendientes { get; set; }

    public virtual DbSet<IftopActualizacionPendientesBi> IftopActualizacionPendientesBis { get; set; }

    public virtual DbSet<IftopActualizacionPendientesTri> IftopActualizacionPendientesTris { get; set; }

    public virtual DbSet<IftopActualizacionResultado> IftopActualizacionResultados { get; set; }

    public virtual DbSet<IftopExtraccionResultado> IftopExtraccionResultados { get; set; }

    public virtual DbSet<IftoperacionesDefinicion> IftoperacionesDefinicions { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<LaboratoriosCondCompra> LaboratoriosCondCompras { get; set; }

    public virtual DbSet<LaboratoriosContacto> LaboratoriosContactos { get; set; }

    public virtual DbSet<LaboratoriosDir> LaboratoriosDirs { get; set; }

    public virtual DbSet<LaboratoriosGrupo> LaboratoriosGrupos { get; set; }

    public virtual DbSet<LaboratoriosObj> LaboratoriosObjs { get; set; }

    public virtual DbSet<LineasNegocio> LineasNegocios { get; set; }

    public virtual DbSet<ListasArticulosUnn> ListasArticulosUnns { get; set; }

    public virtual DbSet<LogErrore> LogErrores { get; set; }

    public virtual DbSet<LogLopd> LogLopds { get; set; }

    public virtual DbSet<LogVenta> LogVentas { get; set; }

    public virtual DbSet<MktTventasClienteLaboratorio> MktTventasClienteLaboratorios { get; set; }

    public virtual DbSet<MotivosCuentasDetalle> MotivosCuentasDetalles { get; set; }

    public virtual DbSet<NivelConsulta> NivelesConsulta { get; set; }

    public virtual DbSet<Origene> Origenes { get; set; }

    public virtual DbSet<Pais> Paises { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersArticulo> PartnersArticulos { get; set; }

    public virtual DbSet<PartnersArticulosObj> PartnersArticulosObjs { get; set; }

    public virtual DbSet<PartnersCompromiso> PartnersCompromisos { get; set; }

    public virtual DbSet<PartnersCompromisosAviso> PartnersCompromisosAvisos { get; set; }

    public virtual DbSet<PartnersCompromisosInf> PartnersCompromisosInfs { get; set; }

    public virtual DbSet<PartnersCompromisosPub> PartnersCompromisosPubs { get; set; }

    public virtual DbSet<PartnersConcepto> PartnersConceptos { get; set; }

    public virtual DbSet<PartnersDefCompromiso> PartnersDefCompromisos { get; set; }

    public virtual DbSet<PartnersDocumento> PartnersDocumentos { get; set; }

    public virtual DbSet<PartnersGestore> PartnersGestores { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidosNf> PedidosNfs { get; set; }

    public virtual DbSet<PedidosNfconformar> PedidosNfconformars { get; set; }

    public virtual DbSet<PedidosNflinea> PedidosNflineas { get; set; }

    public virtual DbSet<PedidosNflineasUnn> PedidosNflineasUnns { get; set; }

    public virtual DbSet<PedidosNfunn> PedidosNfunns { get; set; }

    public virtual DbSet<PerfilAcceso> PerfilesAcceso { get; set; }

    public virtual DbSet<Plataforma> Plataformas { get; set; }

    public virtual DbSet<PlataformasArticulo> PlataformasArticulos { get; set; }

    public virtual DbSet<PlataformasArticulosObserv> PlataformasArticulosObservs { get; set; }

    public virtual DbSet<Poblacion> Poblaciones { get; set; }

    public virtual DbSet<Proceso> Procesos { get; set; }

    public virtual DbSet<Promocione> Promociones { get; set; }

    public virtual DbSet<PromocionesCierre> PromocionesCierres { get; set; }

    public virtual DbSet<PromocionesElemento> PromocionesElementos { get; set; }

    public virtual DbSet<PromocionesElementosCierre> PromocionesElementosCierres { get; set; }

    public virtual DbSet<PromocionesElementosObserv> PromocionesElementosObservs { get; set; }

    public virtual DbSet<PromocionesElementosObservCierre> PromocionesElementosObservCierres { get; set; }

    public virtual DbSet<PromocionesElementosUnnartCierre> PromocionesElementosUnnartCierres { get; set; }

    public virtual DbSet<PromocionesElementosUnncierre> PromocionesElementosUnncierres { get; set; }

    public virtual DbSet<PromocionesFranja> PromocionesFranjas { get; set; }

    public virtual DbSet<PromocionesFranjasCierre> PromocionesFranjasCierres { get; set; }

    public virtual DbSet<PromocionesFranjasLinea> PromocionesFranjasLineas { get; set; }

    public virtual DbSet<PromocionesFranjasLineasCierre> PromocionesFranjasLineasCierres { get; set; }

    public virtual DbSet<PromocionesFranjasUnncierre> PromocionesFranjasUnncierres { get; set; }

    public virtual DbSet<PromocionesObj> PromocionesObjs { get; set; }

    public virtual DbSet<PromocionesObjarticulo> PromocionesObjarticulos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<ProveedoresCalculosPvp> ProveedoresCalculosPvps { get; set; }

    public virtual DbSet<ProveedoresCondCompra> ProveedoresCondCompras { get; set; }

    public virtual DbSet<ProveedoresContacto> ProveedoresContactos { get; set; }

    public virtual DbSet<ProveedoresDir> ProveedoresDirs { get; set; }

    public virtual DbSet<ProveedoresGrupo> ProveedoresGrupos { get; set; }

    public virtual DbSet<ProveedoresNfcondicione> ProveedoresNfcondiciones { get; set; }

    public virtual DbSet<ProveedoresNfcontacto> ProveedoresNfcontactos { get; set; }

    public virtual DbSet<ProveedoresNfdir> ProveedoresNfdirs { get; set; }

    public virtual DbSet<ProveedoresNoFarmaceutico> ProveedoresNoFarmaceuticos { get; set; }

    public virtual DbSet<ProveedoresTrebol> ProveedoresTrebols { get; set; }

    public virtual DbSet<ProveedoresTrebolLaboratorio> ProveedoresTrebolLaboratorios { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<RealesDecreto> RealesDecretos { get; set; }

    public virtual DbSet<RealesDecretosUnn> RealesDecretosUnns { get; set; }

    public virtual DbSet<RolEmpleado> RolesEmpleados { get; set; }

    public virtual DbSet<Sociedade> Sociedades { get; set; }

    public virtual DbSet<SociedadesCcc> SociedadesCccs { get; set; }

    public virtual DbSet<TStockDiarioActualizado> TStockDiarioActualizados { get; set; }

    public virtual DbSet<TarjetasCambio> TarjetasCambios { get; set; }

    public virtual DbSet<TarjetasCambiosCliente> TarjetasCambiosClientes { get; set; }

    public virtual DbSet<TarjetasTipo> TarjetasTipos { get; set; }

    public virtual DbSet<TarjetasTiposUsoVirtual> TarjetasTiposUsoVirtuals { get; set; }

    public virtual DbSet<TempCliente> TempClientes { get; set; }

    public virtual DbSet<TipoServiciosTrebol> TipoServiciosTrebols { get; set; }

    public virtual DbSet<TiposAcuerdoPartner> TiposAcuerdoPartners { get; set; }

    public virtual DbSet<TiposAcuerdoPartnerComp> TiposAcuerdoPartnerComps { get; set; }

    public virtual DbSet<TiposAcuerdoPartnerCompInf> TiposAcuerdoPartnerCompInfs { get; set; }

    public virtual DbSet<TiposAcuerdoPartnerCompPub> TiposAcuerdoPartnerCompPubs { get; set; }

    public virtual DbSet<TiposAcuerdoPartnerConcepto> TiposAcuerdoPartnerConceptos { get; set; }

    public virtual DbSet<TiposIva> TiposIvas { get; set; }

    public virtual DbSet<TiposIvaporcentaje> TiposIvaporcentajes { get; set; }

    public virtual DbSet<TipoVia> TiposVia { get; set; }

    public virtual DbSet<TmpIntermediaProveedor> TmpIntermediaProveedors { get; set; }

    public virtual DbSet<TmpPvlv> TmpPvlvs { get; set; }

    public virtual DbSet<TmpTipocliente> TmpTipoclientes { get; set; }

    public virtual DbSet<TssarticulosEpigrafe> TssarticulosEpigraves { get; set; }

    public virtual DbSet<Tsscliente> Tssclientes { get; set; }

    public virtual DbSet<TssclientesAux> TssclientesAuxes { get; set; }

    public virtual DbSet<TssclientesAuxA> TssclientesAuxAs { get; set; }

    public virtual DbSet<TssclientesCcc> TssclientesCccs { get; set; }

    public virtual DbSet<TssclientesCont> TssclientesConts { get; set; }

    public virtual DbSet<TssclientesDir> TssclientesDirs { get; set; }

    public virtual DbSet<TssclientesVf> TssclientesVfs { get; set; }

    public virtual DbSet<TssfacturasCliente> TssfacturasClientes { get; set; }

    public virtual DbSet<TssfacturasClientesBasis> TssfacturasClientesBases { get; set; }

    public virtual DbSet<TssfacturasClientesEliminada> TssfacturasClientesEliminadas { get; set; }

    public virtual DbSet<TssfacturasClientesLinea> TssfacturasClientesLineas { get; set; }

    public virtual DbSet<TssprocesoAux> TssprocesoAuxes { get; set; }

    public virtual DbSet<TssprocesoAuxLinea> TssprocesoAuxLineas { get; set; }

    public virtual DbSet<TsstclnoGestion> TsstclnoGestions { get; set; }

    public virtual DbSet<TsstiposCliente> TsstiposClientes { get; set; }

    public virtual DbSet<Ubdtraspaso> Ubdtraspasos { get; set; }

    public virtual DbSet<UnidadNegocio> UnidadesNegocio { get; set; }

    public virtual DbSet<UnidadesNegocioCf> UnidadesNegocioCfs { get; set; }

    public virtual DbSet<UnidadesNegocioCie> UnidadesNegocioCies { get; set; }

    public virtual DbSet<UnidadNegocioDb> UnidadesNegocioDb { get; set; }

    public virtual DbSet<UnidadNegocioDireccion> UnidadNegocioDirecciones { get; set; }

    public virtual DbSet<UnidadesNegocioObj> UnidadesNegocioObjs { get; set; }

    public virtual DbSet<UnidadesNegocioSoc> UnidadesNegocioSocs { get; set; }

    public virtual DbSet<UnidadesNegocioVf> UnidadesNegocioVfs { get; set; }

    public virtual DbSet<UnidadesNegocioW> UnidadesNegocioWs { get; set; }

    public virtual DbSet<UnificacionClientesAuditoriaCliente> UnificacionClientesAuditoriaClientes { get; set; }

    public virtual DbSet<UnificacionClientesAuditorium> UnificacionClientesAuditoria { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioJwtRefresh> UsuariosJwtRefresh { get; set; }

    public virtual DbSet<UsuariosUpn> UsuariosUpns { get; set; }

    public virtual DbSet<VendedoresUso> VendedoresUsos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // La configuración del contexto (cadena de conexión, proveedor, etc.)
        // se realiza en tiempo de ejecución mediante WebApplicationExtensions.ConfigureDbContext
        // y en tiempo de diseño mediante TrebolDbContextFactory (IDesignTimeDbContextFactory).
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", DefaultConstants.SQL_COLLATION);

        modelBuilder.Entity<ArticulosBono>(entity =>
        {
            entity.HasKey(e => e.ArtCodigo);

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtDescripcion)
                .HasMaxLength(100)
                .HasColumnName("ART_Descripcion");
            entity.Property(e => e.ArtPrecio)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("ART_Precio");
        });

        modelBuilder.Entity<ArticulosErp>(entity =>
        {
            entity.HasKey(e => e.ArtCodigo);

            entity.ToTable("ArticulosERP");

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtFaltaErp)
                .HasColumnType("datetime")
                .HasColumnName("ART_FAltaERP");
            entity.Property(e => e.ArtFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("ART_FModificacion");
            entity.Property(e => e.ArtMpva)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("ART_MPVA");
            entity.Property(e => e.ArtObservaciones)
                .HasMaxLength(2500)
                .HasColumnName("ART_Observaciones");
            entity.Property(e => e.ArtUaltaErp).HasColumnName("ART_UAltaERP");
            entity.Property(e => e.ArtUmodificacion).HasColumnName("ART_UModificacion");
        });

        modelBuilder.Entity<ArticulosErpsinonimo>(entity =>
        {
            entity.HasKey(e => new { e.ArtCodigo, e.ArtEan });

            entity.ToTable("ArticulosERPSinonimos");

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtEan)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_EAN");
            entity.Property(e => e.ArtEanprincipal).HasColumnName("ART_EANPrincipal");

            entity.HasOne(d => d.ArtCodigoNavigation).WithMany(p => p.ArticulosErpsinonimos)
                .HasForeignKey(d => d.ArtCodigo)
                .HasConstraintName("FK_ArticulosERPSinonimos_ArticulosERP");
        });

        modelBuilder.Entity<ArticulosExclBonif>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.ArtCodigo });

            entity.ToTable("ArticulosExclBonif");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");

            entity.HasOne(d => d.Unn).WithMany(p => p.ArticulosExclBonifs)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_ArticulosExclBonif_UnidadesNegocio");
        });

        modelBuilder.Entity<ArticulosMod>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_Articulos_MOD");

            entity.Property(e => e.Codigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Dtop)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("DTOP");
            entity.Property(e => e.Dtot)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("DTOT");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("IVA");
            entity.Property(e => e.Pvl)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PVL");
            entity.Property(e => e.Pvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PVP");
        });

        modelBuilder.Entity<ArticulosModBidum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Articulos_MOD_BIDA");

            entity.Property(e => e.Codigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Familia).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("IVA");
            entity.Property(e => e.Libre).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Pv)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PV");
            entity.Property(e => e.Pvf)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PVF");
            entity.Property(e => e.Pvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PVP");
        });

        modelBuilder.Entity<ArticulosModMebidaB>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Articulos_MOD_MEBIDA_B");

            entity.Property(e => e.Codigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Pva)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PVA");
            entity.Property(e => e.Pvl)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PVL");
            entity.Property(e => e.Pvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PVP");
        });

        modelBuilder.Entity<ArticulosModMebidum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Articulos_MOD_MEBIDA");

            entity.Property(e => e.Codigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AvisoDocumento>(entity =>
        {
            entity.HasKey(e => new { e.AviId, e.AvdId });

            entity.Property(e => e.AviId).HasColumnName("AVI_ID");
            entity.Property(e => e.AvdId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AVD_ID");
            entity.Property(e => e.DocLink)
                .HasMaxLength(255)
                .HasColumnName("DOC_Link");

            entity.HasOne(d => d.Avi).WithMany(p => p.AvisosDocumentos)
                .HasForeignKey(d => d.AviId)
                .HasConstraintName("FK_AvisosDocumentos_AvisosInternos");
        });

        modelBuilder.Entity<AvisoInterno>(entity =>
        {
            entity.HasKey(e => e.AviId);

            entity.Property(e => e.AviId).HasColumnName("AVI_ID");
            entity.Property(e => e.AviAsunto)
                .HasMaxLength(255)
                .HasColumnName("AVI_Asunto");
            entity.Property(e => e.AviFecha)
                .HasColumnType("datetime")
                .HasColumnName("AVI_Fecha");
            entity.Property(e => e.AviImportancia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AVI_Importancia");
            entity.Property(e => e.AviLink)
                .HasMaxLength(300)
                .HasColumnName("AVI_Link");
            entity.Property(e => e.AviMensaje)
                .HasMaxLength(1500)
                .HasColumnName("AVI_Mensaje");
            entity.Property(e => e.AviTarget)
                .HasMaxLength(10)
                .HasColumnName("AVI_Target");
            entity.Property(e => e.AviTextoLink)
                .HasMaxLength(200)
                .HasColumnName("AVI_TextoLink");
            entity.Property(e => e.AviVisto).HasColumnName("AVI_Visto");
            entity.Property(e => e.ProId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRO_ID");
            entity.Property(e => e.UsuIddestino).HasColumnName("USU_IDDestino");
            entity.Property(e => e.UsuIdorigen).HasColumnName("USU_IDOrigen");

            entity.HasOne(d => d.Proceso).WithMany(p => p.AvisosInternos)
                .HasForeignKey(d => d.ProId);
        });

        modelBuilder.Entity<BajaArticuloErp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BajaArticuloERP");

            entity.Property(e => e.DescArticu).HasMaxLength(100);
            entity.Property(e => e.DescLaboratorio).HasMaxLength(100);
            entity.Property(e => e.DescPlataforma).HasMaxLength(100);
            entity.Property(e => e.DescTipoIva).HasMaxLength(50);
            entity.Property(e => e.FechaInserccion).HasColumnType("datetime");
            entity.Property(e => e.IdCodigoArticu)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<BajaCliente>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CliApellido1)
                .HasMaxLength(100)
                .HasColumnName("CLI_Apellido1");
            entity.Property(e => e.CliApellido2)
                .HasMaxLength(100)
                .HasColumnName("CLI_Apellido2");
            entity.Property(e => e.CliEmail)
                .HasMaxLength(255)
                .HasColumnName("CLI_Email");
            entity.Property(e => e.CliFalta)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FAlta");
            entity.Property(e => e.CliFbaja)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FBaja");
            entity.Property(e => e.CliFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FModificacion");
            entity.Property(e => e.CliFnacimiento)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FNacimiento");
            entity.Property(e => e.CliFultMovimiento)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FUltMovimiento");
            entity.Property(e => e.CliFultVenta)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FUltVenta");
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CliIdfiscal)
                .HasMaxLength(15)
                .HasColumnName("CLI_IDFiscal");
            entity.Property(e => e.CliMovil)
                .HasMaxLength(15)
                .HasColumnName("CLI_Movil");
            entity.Property(e => e.CliNombre)
                .HasMaxLength(100)
                .HasColumnName("CLI_Nombre");
            entity.Property(e => e.CliRecibirNotificaciones).HasColumnName("CLI_RecibirNotificaciones");
            entity.Property(e => e.CliSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_Sexo");
            entity.Property(e => e.CliTelf)
                .HasMaxLength(15)
                .HasColumnName("CLI_Telf");
            entity.Property(e => e.CliUalta).HasColumnName("CLI_UAlta");
            entity.Property(e => e.CliUbaja).HasColumnName("CLI_UBaja");
            entity.Property(e => e.CliUmodificacion).HasColumnName("CLI_UModificacion");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.FechaAuditoria)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_Auditoria");
            entity.Property(e => e.OriId).HasColumnName("ORI_ID");
            entity.Property(e => e.Origen)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ORIGEN");
            entity.Property(e => e.UnnIdultMovimiento).HasColumnName("UNN_IDUltMovimiento");
            entity.Property(e => e.UnnIdultVenta).HasColumnName("UNN_IDUltVenta");
        });

        modelBuilder.Entity<BajaClientesComentario>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ClcAutomatico).HasColumnName("CLC_Automatico");
            entity.Property(e => e.ClcAviso).HasColumnName("CLC_Aviso");
            entity.Property(e => e.ClcComentarios)
                .HasMaxLength(500)
                .HasColumnName("CLC_Comentarios");
            entity.Property(e => e.ClcFecha)
                .HasColumnType("datetime")
                .HasColumnName("CLC_Fecha");
            entity.Property(e => e.ClcUalta).HasColumnName("CLC_UAlta");
            entity.Property(e => e.ClcVisto).HasColumnName("CLC_Visto");
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
        });

        modelBuilder.Entity<BajaClientesCuenta>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
        });

        modelBuilder.Entity<BajaClientesTarjeta>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CltActiva).HasColumnName("CLT_Activa");
            entity.Property(e => e.CltFactivacion)
                .HasColumnType("datetime")
                .HasColumnName("CLT_FActivacion");
            entity.Property(e => e.CltFalta)
                .HasColumnType("datetime")
                .HasColumnName("CLT_Falta");
            entity.Property(e => e.CltFanulacion)
                .HasColumnType("datetime")
                .HasColumnName("CLT_FAnulacion");
            entity.Property(e => e.CltFcaducidad)
                .HasColumnType("datetime")
                .HasColumnName("CLT_FCaducidad");
            entity.Property(e => e.CltMotivoAnulacion)
                .HasMaxLength(100)
                .HasColumnName("CLT_MotivoAnulacion");
            entity.Property(e => e.CltUactivacion).HasColumnName("CLT_UActivacion");
            entity.Property(e => e.CltUalta).HasColumnName("CLT_UAlta");
            entity.Property(e => e.CltUanulacion).HasColumnName("CLT_UAnulacion");
            entity.Property(e => e.EnvLote).HasColumnName("ENV_Lote");
            entity.Property(e => e.TarId)
                .HasMaxLength(13)
                .HasColumnName("TAR_ID");
            entity.Property(e => e.TatId).HasColumnName("TAT_ID");
            entity.Property(e => e.UnnIdactivacion).HasColumnName("UNN_IDActivacion");
            entity.Property(e => e.UnnIdanulacion).HasColumnName("UNN_IDAnulacion");
        });

        modelBuilder.Entity<BajaCuenta>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CueBonos).HasColumnName("CUE_Bonos");
            entity.Property(e => e.CueBonosImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUE_BonosImporte");
            entity.Property(e => e.CueFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("CUE_FModificacion");
            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.CueImpBonificacion)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUE_ImpBonificacion");
            entity.Property(e => e.CuePuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUE_Puntos");
            entity.Property(e => e.CueUmodificacion)
                .HasMaxLength(50)
                .HasColumnName("CUE_UModificacion");
        });

        modelBuilder.Entity<BajaCuentasBono>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.CubFechaCaducidad)
                .HasColumnType("datetime")
                .HasColumnName("CUB_FechaCaducidad");
            entity.Property(e => e.CubFechaUso)
                .HasColumnType("datetime")
                .HasColumnName("CUB_FechaUso");
            entity.Property(e => e.CubId).HasColumnName("CUB_ID");
            entity.Property(e => e.CubUsado).HasColumnName("CUB_Usado");
            entity.Property(e => e.CubUsoForzado).HasColumnName("CUB_UsoForzado");
            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.TarId)
                .HasMaxLength(13)
                .HasColumnName("TAR_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UsuId).HasColumnName("USU_ID");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");
        });

        modelBuilder.Entity<BajaCuentasDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BajaCuentasDetalle");

            entity.Property(e => e.ArtBono)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Bono");
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CudAnulado).HasColumnName("CUD_Anulado");
            entity.Property(e => e.CudBono).HasColumnName("CUD_Bono");
            entity.Property(e => e.CudFalta)
                .HasColumnType("datetime")
                .HasColumnName("CUD_FAlta");
            entity.Property(e => e.CudFecha)
                .HasColumnType("datetime")
                .HasColumnName("CUD_Fecha");
            entity.Property(e => e.CudFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("CUD_FModificacion");
            entity.Property(e => e.CudForzado).HasColumnName("CUD_Forzado");
            entity.Property(e => e.CudHistorico).HasColumnName("CUD_Historico");
            entity.Property(e => e.CudId).HasColumnName("CUD_ID");
            entity.Property(e => e.CudImporteBonificable)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUD_ImporteBonificable");
            entity.Property(e => e.CudImporteBruto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUD_ImporteBruto");
            entity.Property(e => e.CudOperacion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CUD_Operacion");
            entity.Property(e => e.CudPuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUD_Puntos");
            entity.Property(e => e.CudTicket)
                .HasMaxLength(50)
                .HasColumnName("CUD_Ticket");
            entity.Property(e => e.CudUalta).HasColumnName("CUD_UAlta");
            entity.Property(e => e.CudUmodificacion).HasColumnName("CUD_UModificacion");
            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.MotId).HasColumnName("MOT_ID");
            entity.Property(e => e.TarId)
                .HasMaxLength(13)
                .HasColumnName("TAR_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");
        });

        modelBuilder.Entity<BajaCuentasDetalleArticulo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.CdaCantidad).HasColumnName("CDA_Cantidad");
            entity.Property(e => e.CdaImporteBonif)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CDA_ImporteBonif");
            entity.Property(e => e.CdaImporteVenta)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CDA_ImporteVenta");
            entity.Property(e => e.CdaLinea).HasColumnName("CDA_Linea");
            entity.Property(e => e.CdaPuntos)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CDA_Puntos");
            entity.Property(e => e.CdaTipoAportacion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CDA_TipoAportacion");
            entity.Property(e => e.CudId).HasColumnName("CUD_ID");
        });

        modelBuilder.Entity<BajaCuentasDetalleHistorico>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BajaCuentasDetalleHistorico");

            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.CuhAnio).HasColumnName("CUH_Anio");
            entity.Property(e => e.CuhBonos).HasColumnName("CUH_Bonos");
            entity.Property(e => e.CuhBonosCanjeImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_BonosCanjeImporte");
            entity.Property(e => e.CuhBonosCanjeados).HasColumnName("CUH_BonosCanjeados");
            entity.Property(e => e.CuhBonosImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_BonosImporte");
            entity.Property(e => e.CuhImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_Importe");
            entity.Property(e => e.CuhImporteBonificable)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_ImporteBonificable");
            entity.Property(e => e.CuhMes).HasColumnName("CUH_Mes");
            entity.Property(e => e.CuhNumOperaciones).HasColumnName("CUH_NumOperaciones");
            entity.Property(e => e.CuhPuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_Puntos");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.BanCodigo);

            entity.Property(e => e.BanCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BAN_Codigo");
            entity.Property(e => e.BanNombre)
                .HasMaxLength(50)
                .HasColumnName("BAN_Nombre");
        });

        modelBuilder.Entity<BtarticuloErp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BTArticuloERP");

            entity.Property(e => e.DescArticu).HasMaxLength(100);
            entity.Property(e => e.DescLaboratorio).HasMaxLength(100);
            entity.Property(e => e.DescPlataforma).HasMaxLength(100);
            entity.Property(e => e.DescTipoIva).HasMaxLength(50);
            entity.Property(e => e.FechaInserccion).HasColumnType("datetime");
            entity.Property(e => e.IdCodigoArticu)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<CalendarioFestivo>(entity =>
        {
            entity.HasKey(e => e.CafId);

            entity.Property(e => e.CafId).HasColumnName("CAF_ID");
            entity.Property(e => e.CafAno).HasColumnName("CAF_ANO");
            entity.Property(e => e.CafDescripcion)
                .HasMaxLength(80)
                .HasColumnName("CAF_Descripcion");
        });

        modelBuilder.Entity<CalendarioFestivosDia>(entity =>
        {
            entity.HasKey(e => new { e.CafId, e.CafFestivo });

            entity.Property(e => e.CafId).HasColumnName("CAF_ID");
            entity.Property(e => e.CafFestivo)
                .HasColumnType("datetime")
                .HasColumnName("CAF_Festivo");

            entity.HasOne(d => d.Caf).WithMany(p => p.CalendarioFestivosDia)
                .HasForeignKey(d => d.CafId)
                .HasConstraintName("FK_CalendarioFestivosDias_CalendarioFestivos");
        });

        modelBuilder.Entity<Campania>(entity =>
        {
            entity.HasKey(e => e.CamId);

            entity.Property(e => e.CamId).HasColumnName("CAM_ID");
            entity.Property(e => e.CamClase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("'T': Tarjetas 'C': Clientes")
                .HasColumnName("CAM_Clase");
            entity.Property(e => e.CamDefecto).HasColumnName("CAM_Defecto");
            entity.Property(e => e.CamDescripcion)
                .HasMaxLength(200)
                .HasColumnName("CAM_Descripcion");
            entity.Property(e => e.CamFalta)
                .HasColumnType("datetime")
                .HasColumnName("CAM_Falta");
            entity.Property(e => e.CamFechaFin)
                .HasColumnType("datetime")
                .HasColumnName("CAM_FechaFin");
            entity.Property(e => e.CamFechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("CAM_FechaInicio");
            entity.Property(e => e.CamFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("CAM_FModificacion");
            entity.Property(e => e.CamUalta).HasColumnName("CAM_UAlta");
            entity.Property(e => e.CamUmodificacion).HasColumnName("CAM_UModificacion");

            entity.HasMany(d => d.Unns).WithMany(p => p.Cams)
                .UsingEntity<Dictionary<string, object>>(
                    "CampaniasUnidadesNegocio",
                    r => r.HasOne<UnidadNegocio>().WithMany()
                        .HasForeignKey("UnnId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CampaniasUnidadesNegocio_UnidadesNegocio"),
                    l => l.HasOne<Campania>().WithMany()
                        .HasForeignKey("CamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CampaniasUnidadesNegocio_Campanias"),
                    j =>
                    {
                        j.HasKey("CamId", "UnnId").HasName("PK_CampaniasUnidadesNegocio_1");
                        j.ToTable("CampaniasUnidadesNegocio");
                        j.IndexerProperty<int>("CamId").HasColumnName("CAM_ID");
                        j.IndexerProperty<int>("UnnId").HasColumnName("UNN_ID");
                    });
        });

        modelBuilder.Entity<CampaniasArticulo>(entity =>
        {
            entity.HasKey(e => e.CaaId);

            entity.Property(e => e.CaaId).HasColumnName("CAA_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtDescripcion)
                .HasMaxLength(100)
                .HasColumnName("ART_Descripcion");
            entity.Property(e => e.CaaDescFamilia)
                .HasMaxLength(30)
                .HasColumnName("CAA_DescFamilia");
            entity.Property(e => e.CaaFamilia).HasColumnName("CAA_Familia");
            entity.Property(e => e.CaaPorcentaje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CAA_Porcentaje");
        });

        modelBuilder.Entity<CampaniasCliente>(entity =>
        {
            entity.HasKey(e => e.CacId);

            entity.Property(e => e.CacId).HasColumnName("CAC_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.CabCaducidad).HasColumnName("CAB_Caducidad");
            entity.Property(e => e.CabImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CAB_Importe");
            entity.Property(e => e.CabMensaje)
                .HasMaxLength(255)
                .HasColumnName("CAB_Mensaje");
            entity.Property(e => e.CabPuntos)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CAB_Puntos");
            entity.Property(e => e.CamId).HasColumnName("CAM_ID");
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");

            entity.HasOne(d => d.ArtCodigoNavigation).WithMany(p => p.CampaniasClientes)
                .HasForeignKey(d => d.ArtCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CampaniasClientes_ArticulosBonos");

            entity.HasOne(d => d.Cam).WithMany(p => p.CampaniasClientes)
                .HasForeignKey(d => d.CamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CampaniasClientes_Campanias");

            entity.HasOne(d => d.Cli).WithMany(p => p.CampaniasClientes)
                .HasForeignKey(d => d.CliId)
                .HasConstraintName("FK_CampaniasClientes_Clientes");

            entity.HasMany(d => d.Caas).WithMany(p => p.Cacs)
                .UsingEntity<Dictionary<string, object>>(
                    "CampaniasClientesArticulo",
                    r => r.HasOne<CampaniasArticulo>().WithMany()
                        .HasForeignKey("CaaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CampaniasClientesArticulos_CampaniasArticulos"),
                    l => l.HasOne<CampaniasCliente>().WithMany()
                        .HasForeignKey("CacId")
                        .HasConstraintName("FK_CampaniasClientesArticulos_CampaniasClientes"),
                    j =>
                    {
                        j.HasKey("CacId", "CaaId");
                        j.ToTable("CampaniasClientesArticulos");
                        j.IndexerProperty<int>("CacId").HasColumnName("CAC_ID");
                        j.IndexerProperty<int>("CaaId").HasColumnName("CAA_ID");
                    });
        });

        modelBuilder.Entity<CampaniasTarjetasTipo>(entity =>
        {
            entity.HasKey(e => e.CttId);

            entity.Property(e => e.CttId).HasColumnName("CTT_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.CabCaducidad).HasColumnName("CAB_Caducidad");
            entity.Property(e => e.CabImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CAB_Importe");
            entity.Property(e => e.CabMensaje)
                .HasMaxLength(255)
                .HasColumnName("CAB_Mensaje");
            entity.Property(e => e.CabPuntos)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CAB_Puntos");
            entity.Property(e => e.CamId).HasColumnName("CAM_ID");
            entity.Property(e => e.TatId).HasColumnName("TAT_ID");

            entity.HasOne(d => d.ArtCodigoNavigation).WithMany(p => p.CampaniasTarjetasTipos)
                .HasForeignKey(d => d.ArtCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CampaniasTarjetasTipos_ArticulosBonos");

            entity.HasOne(d => d.Cam).WithMany(p => p.CampaniasTarjetasTipos)
                .HasForeignKey(d => d.CamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CampaniasTarjetasTipos_Campanias");

            entity.HasOne(d => d.Tat).WithMany(p => p.CampaniasTarjetasTipos)
                .HasForeignKey(d => d.TatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CampaniasTarjetasTipos_TarjetasTipos");

            entity.HasMany(d => d.Caas).WithMany(p => p.Ctts)
                .UsingEntity<Dictionary<string, object>>(
                    "CampaniasTarjetasTiposArticulo",
                    r => r.HasOne<CampaniasArticulo>().WithMany()
                        .HasForeignKey("CaaId")
                        .HasConstraintName("FK_CampaniasTarjetasTiposArticulos_CampaniasArticulos"),
                    l => l.HasOne<CampaniasTarjetasTipo>().WithMany()
                        .HasForeignKey("CttId")
                        .HasConstraintName("FK_CampaniasTarjetasTiposArticulos_CampaniasTarjetasTipos"),
                    j =>
                    {
                        j.HasKey("CttId", "CaaId").HasName("PK_CampaniasTiposTarjetasArticulos");
                        j.ToTable("CampaniasTarjetasTiposArticulos");
                        j.IndexerProperty<int>("CttId").HasColumnName("CTT_ID");
                        j.IndexerProperty<int>("CaaId").HasColumnName("CAA_ID");
                    });
        });

        modelBuilder.Entity<CanonTrebolDef>(entity =>
        {
            entity.HasKey(e => e.UnnId);

            entity.ToTable("CanonTrebolDef");

            entity.Property(e => e.UnnId)
                .ValueGeneratedNever()
                .HasColumnName("UNN_ID");
            entity.Property(e => e.CtdComentario)
                .HasMaxLength(1000)
                .HasColumnName("CTD_Comentario");
            entity.Property(e => e.CtdDescripcion)
                .HasMaxLength(75)
                .HasColumnName("CTD_Descripcion");
            entity.Property(e => e.CtdExclRdc).HasColumnName("CTD_ExclRDC");
            entity.Property(e => e.CtdImpMinimo)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CTD_ImpMinimo");
            entity.Property(e => e.CtdPorCalculo)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CTD_PorCalculo");
            entity.Property(e => e.CtdProcSql)
                .HasMaxLength(255)
                .HasColumnName("CTD_ProcSQL");
            entity.Property(e => e.CtdUltAbono)
                .HasColumnType("datetime")
                .HasColumnName("CTD_UltAbono");
            entity.Property(e => e.CtdUltFacturacion)
                .HasColumnType("datetime")
                .HasColumnName("CTD_UltFacturacion");

            entity.HasOne(d => d.Unn).WithOne(p => p.CanonTrebolDef)
                .HasForeignKey<CanonTrebolDef>(d => d.UnnId)
                .HasConstraintName("FK_CanonTrebolDef_UnidadesNegocio");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CatId);

            entity.Property(e => e.CatId).HasColumnName("CAT_ID");
            entity.Property(e => e.CatNombre)
                .HasMaxLength(75)
                .HasColumnName("CAT_Nombre");
        });

        modelBuilder.Entity<CerrarCondicione>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
        });

        modelBuilder.Entity<ClasificComercialTemp>(entity =>
        {
            entity.HasKey(e => e.CctId);

            entity.ToTable("ClasificComercialTemp");

            entity.Property(e => e.CctId).HasColumnName("CCT_ID");
            entity.Property(e => e.CctDescripcion)
                .HasMaxLength(100)
                .HasColumnName("CCT_Descripcion");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CliId);

            entity.ToTable(tb => tb.HasTrigger("ClientesCambios_ERPWeb"));

            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CliApellido1)
                .HasMaxLength(255)
                .HasColumnName("CLI_Apellido1");
            entity.Property(e => e.CliApellido2)
                .HasMaxLength(100)
                .HasColumnName("CLI_Apellido2");
            entity.Property(e => e.CliEmail)
                .HasMaxLength(255)
                .HasColumnName("CLI_Email");
            entity.Property(e => e.CliFalta)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FAlta");
            entity.Property(e => e.CliFbaja)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FBaja");
            entity.Property(e => e.CliFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FModificacion");
            entity.Property(e => e.CliFnacimiento)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FNacimiento");
            entity.Property(e => e.CliFultMovimiento)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FUltMovimiento");
            entity.Property(e => e.CliFultVenta)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FUltVenta");
            entity.Property(e => e.CliIdfiscal)
                .HasMaxLength(15)
                .HasColumnName("CLI_IDFiscal");
            entity.Property(e => e.CliMovil)
                .HasMaxLength(15)
                .HasColumnName("CLI_Movil");
            entity.Property(e => e.CliNombre)
                .HasMaxLength(100)
                .HasColumnName("CLI_Nombre");
            entity.Property(e => e.CliRecibirNotificaciones).HasColumnName("CLI_RecibirNotificaciones");
            entity.Property(e => e.CliSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_Sexo");
            entity.Property(e => e.CliTelf)
                .HasMaxLength(15)
                .HasColumnName("CLI_Telf");
            entity.Property(e => e.CliUalta).HasColumnName("CLI_UAlta");
            entity.Property(e => e.CliUbaja).HasColumnName("CLI_UBaja");
            entity.Property(e => e.CliUmodificacion).HasColumnName("CLI_UModificacion");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.OriId).HasColumnName("ORI_ID");
            entity.Property(e => e.UnnIdultMovimiento).HasColumnName("UNN_IDUltMovimiento");
            entity.Property(e => e.UnnIdultVenta).HasColumnName("UNN_IDUltVenta");

            entity.HasOne(d => d.Dir).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.DirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Direcciones");

            entity.HasOne(d => d.Ori).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.OriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Origenes");

            entity.HasMany(d => d.Cues).WithMany(p => p.Clis)
                .UsingEntity<Dictionary<string, object>>(
                    "ClientesCuenta",
                    r => r.HasOne<Cuenta>().WithMany()
                        .HasForeignKey("CueId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ClientesCuentas_Cuentas"),
                    l => l.HasOne<Cliente>().WithMany()
                        .HasForeignKey("CliId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ClientesCuentas_Clientes"),
                    j =>
                    {
                        j.HasKey("CliId", "CueId").HasName("PK_ClientesCuentas_1");
                        j.ToTable("ClientesCuentas");
                        j.IndexerProperty<int>("CliId").HasColumnName("CLI_ID");
                        j.IndexerProperty<int>("CueId").HasColumnName("CUE_ID");
                    });
        });

        modelBuilder.Entity<ClientesCalidadDato>(entity =>
        {
            entity.HasKey(e => e.CliId);

            entity.ToTable("ClientesCalidadDato");

            entity.Property(e => e.CliId)
                .ValueGeneratedNever()
                .HasColumnName("CLI_ID");
            entity.Property(e => e.CliEMail)
                .HasMaxLength(255)
                .HasColumnName("CLI_eMail");
            entity.Property(e => e.CliIdfiscalAnterior)
                .HasMaxLength(15)
                .HasColumnName("CLI_IDFiscalAnterior");
            entity.Property(e => e.CliIdfiscalNueva)
                .HasMaxLength(15)
                .HasColumnName("CLI_IDFiscalNueva");
            entity.Property(e => e.EMailIncorrecto).HasColumnName("eMailIncorrecto");
            entity.Property(e => e.IdfiscalIncorrecta).HasColumnName("IDFiscalIncorrecta");

            entity.HasOne(d => d.Cli).WithOne(p => p.ClientesCalidadDato)
                .HasForeignKey<ClientesCalidadDato>(d => d.CliId)
                .HasConstraintName("FK_ClientesCalidadDato_Clientes");
        });

        modelBuilder.Entity<ClientesCambiosErpweb>(entity =>
        {
            entity.ToTable("ClientesCambiosERPWeb");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos).HasMaxLength(255);
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .HasColumnName("Correo Electronico");
            entity.Property(e => e.Dni)
                .HasMaxLength(255)
                .HasColumnName("DNI");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasMaxLength(255);
            entity.Property(e => e.IdTarjeta)
                .HasMaxLength(255)
                .HasColumnName("ID_Tarjeta");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<ClientesComentario>(entity =>
        {
            entity.HasKey(e => new { e.CliId, e.ClcFecha }).HasName("PK_ClientesComentarios_1");

            entity.HasIndex(e => new { e.CliId, e.ClcFecha }, "IX_ClientesComentarios");

            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.ClcFecha)
                .HasColumnType("datetime")
                .HasColumnName("CLC_Fecha");
            entity.Property(e => e.ClcAutomatico).HasColumnName("CLC_Automatico");
            entity.Property(e => e.ClcAviso).HasColumnName("CLC_Aviso");
            entity.Property(e => e.ClcComentarios)
                .HasMaxLength(500)
                .HasColumnName("CLC_Comentarios");
            entity.Property(e => e.ClcUalta).HasColumnName("CLC_UAlta");
            entity.Property(e => e.ClcVisto).HasColumnName("CLC_Visto");

            entity.HasOne(d => d.Cli).WithMany(p => p.ClientesComentarios)
                .HasForeignKey(d => d.CliId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientesObservaciones_Clientes");
        });

        modelBuilder.Entity<ClientesDocumentosLopd>(entity =>
        {
            entity.HasKey(e => new { e.CliId, e.DocId }).HasName("PK_ClientesDocumentosLOPD_1");

            entity.ToTable("ClientesDocumentosLOPD");

            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.DocId).HasColumnName("DOC_ID");
            entity.Property(e => e.CldCodBar)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLD_CodBar");
            entity.Property(e => e.CldFalta)
                .HasColumnType("datetime")
                .HasColumnName("CLD_FAlta");
            entity.Property(e => e.CldUalta).HasColumnName("CLD_UAlta");
            entity.Property(e => e.EnvLote).HasColumnName("ENV_Lote");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");

            entity.HasOne(d => d.Cli).WithMany(p => p.ClientesDocumentosLopds)
                .HasForeignKey(d => d.CliId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientesDocumentosLOPD_Clientes");

            entity.HasOne(d => d.Doc).WithMany(p => p.ClientesDocumentosLopds)
                .HasForeignKey(d => d.DocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientesDocumentosLOPD_DocumentosLOPD");
        });

        modelBuilder.Entity<ClientesErpWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ClientesErpWeb");

            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdErp).HasColumnName("idErp");
            entity.Property(e => e.IdWeb)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClientesTarjeta>(entity =>
        {
            entity.HasKey(e => new { e.CliId, e.TarId }).HasName("PK_ClientesTarjetas_1");

            entity.HasIndex(e => e.TarId, "IX_ClientesTarjetas");

            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.TarId)
                .HasMaxLength(13)
                .HasColumnName("TAR_ID");
            entity.Property(e => e.CltActiva).HasColumnName("CLT_Activa");
            entity.Property(e => e.CltFactivacion)
                .HasColumnType("datetime")
                .HasColumnName("CLT_FActivacion");
            entity.Property(e => e.CltFalta)
                .HasColumnType("datetime")
                .HasColumnName("CLT_Falta");
            entity.Property(e => e.CltFanulacion)
                .HasColumnType("datetime")
                .HasColumnName("CLT_FAnulacion");
            entity.Property(e => e.CltFcaducidad)
                .HasColumnType("datetime")
                .HasColumnName("CLT_FCaducidad");
            entity.Property(e => e.CltMotivoAnulacion)
                .HasMaxLength(100)
                .HasColumnName("CLT_MotivoAnulacion");
            entity.Property(e => e.CltUactivacion).HasColumnName("CLT_UActivacion");
            entity.Property(e => e.CltUalta).HasColumnName("CLT_UAlta");
            entity.Property(e => e.CltUanulacion).HasColumnName("CLT_UAnulacion");
            entity.Property(e => e.EnvLote).HasColumnName("ENV_Lote");
            entity.Property(e => e.TatId).HasColumnName("TAT_ID");
            entity.Property(e => e.UnnIdactivacion).HasColumnName("UNN_IDActivacion");
            entity.Property(e => e.UnnIdanulacion).HasColumnName("UNN_IDAnulacion");

            entity.HasOne(d => d.Cli).WithMany(p => p.ClientesTarjeta)
                .HasForeignKey(d => d.CliId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientesTarjetas_Clientes");

            entity.HasOne(d => d.Tat).WithMany(p => p.ClientesTarjeta)
                .HasForeignKey(d => d.TatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientesTarjetas_TarjetasTipos");
        });

        modelBuilder.Entity<CodigodLabDel>(entity =>
        {
            entity.HasKey(e => e.LabCodigo);

            entity.ToTable("CodigodLabDel");

            entity.Property(e => e.LabCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
        });

        modelBuilder.Entity<CodigosBorrado>(entity =>
        {
            entity.HasKey(e => new { e.CobTipo, e.CobCodigo });

            entity.Property(e => e.CobTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COB_Tipo");
            entity.Property(e => e.CobCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COB_Codigo");
        });

        modelBuilder.Entity<ComunidadAut>(entity =>
        {
            entity.HasKey(e => e.CauId);

            entity.ToTable("ComunidadesAut");

            entity.Property(e => e.CauId).HasColumnName("CAU_ID");
            entity.Property(e => e.CauConsejo).HasColumnName("CAU_Consejo");
            entity.Property(e => e.CauExencionIva)
                .HasColumnName("CAU_ExencionIVA");
            entity.Property(e => e.CauNombre)
                .HasMaxLength(80)
                .HasColumnName("CAU_Nombre")
                .IsRequired();
            entity.Property(e => e.PaiId)
                .HasColumnName("PAI_ID");
            entity.HasOne(d => d.Pais).WithMany(p => p.ComunidadesAut)
                .HasForeignKey(d => d.PaiId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_ComunidadesAut_Paises");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity.HasKey(e => e.ConId);

            entity.ToTable("Configuracion");

            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConActualizarBi).HasColumnName("CON_ActualizarBI");
            entity.Property(e => e.ConMaxLotesDocum).HasColumnName("CON_MaxLotesDocum");
            entity.Property(e => e.ConMaxLotesTarjetas).HasColumnName("CON_MaxLotesTarjetas");
            entity.Property(e => e.ConMensajeOrganizacion)
                .HasMaxLength(100)
                .HasColumnName("CON_MensajeOrganizacion");
            entity.Property(e => e.ConMma)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CON_MMA");
            entity.Property(e => e.ConMmp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CON_MMP");
            entity.Property(e => e.ConPathEmisionFacturasTrebol)
                .HasMaxLength(100)
                .HasColumnName("CON_PathEmisionFacturasTrebol");
            entity.Property(e => e.ConPathEmisionFacturasTss)
                .HasMaxLength(255)
                .HasColumnName("CON_PathEmisionFacturasTSS");
            entity.Property(e => e.ConPathEmisionInformeResumen)
                .HasMaxLength(255)
                .HasColumnName("CON_PathEmisionInformeResumen");
            entity.Property(e => e.ConPathEmisionPedidosPnf)
                .HasMaxLength(100)
                .HasColumnName("CON_PathEmisionPedidosPNF");
            entity.Property(e => e.ConPathExcelCargaObjPromo)
                .HasMaxLength(255)
                .HasColumnName("CON_PathExcelCargaObjPromo");
        });

        modelBuilder.Entity<ConsultaSql>(entity =>
        {
            entity.HasKey(e => e.ConId);

            entity.ToTable("ConsultasSQL");

            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConDescrip)
                .HasMaxLength(100)
                .HasColumnName("CON_Descrip");
            entity.Property(e => e.ConFalta)
                .HasComment("Fecha de Alta")
                .HasColumnType("datetime")
                .HasColumnName("CON_FAlta");
            entity.Property(e => e.ConFechafin)
                .HasColumnType("datetime")
                .HasColumnName("CON_FECHAFIN");
            entity.Property(e => e.ConFechaini)
                .HasColumnType("datetime")
                .HasColumnName("CON_FECHAINI");
            entity.Property(e => e.ConFmodificacion)
                .HasComment("Fecha Modificación")
                .HasColumnType("datetime")
                .HasColumnName("CON_FModificacion");
            entity.Property(e => e.ConHorafin)
                .HasColumnType("datetime")
                .HasColumnName("CON_HORAFIN");
            entity.Property(e => e.ConHoraini)
                .HasColumnType("datetime")
                .HasColumnName("CON_HORAINI");
            entity.Property(e => e.ConObservaciones)
                .HasColumnType("text")
                .HasColumnName("CON_Observaciones");
            entity.Property(e => e.ConSentencia)
                .HasColumnType("text")
                .HasColumnName("CON_Sentencia");
            entity.Property(e => e.ConTimeOut).HasColumnName("CON_TimeOut");
            entity.Property(e => e.ConUalta)
                .HasComment("Id. Usuario Alta")
                .HasColumnName("CON_UAlta");
            entity.Property(e => e.ConUmodificacion)
                .HasComment("Identificador del último Usuario que modificó")
                .HasColumnName("CON_UModificacion");
            entity.Property(e => e.ConVigente).HasColumnName("CON_Vigente");
            entity.Property(e => e.NicId).HasColumnName("NIC_ID");

            entity.HasOne(d => d.Nivel).WithMany(p => p.ConsultasSql)
                .HasForeignKey(d => d.NicId)
                .HasConstraintName("FK_ConsultasSQL_NivelesConsultas");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.ConId);

            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConFax)
                .HasMaxLength(15)
                .HasColumnName("CON_FAX");
            entity.Property(e => e.ConMail)
                .HasMaxLength(255)
                .HasColumnName("CON_Mail");
            entity.Property(e => e.ConMovil)
                .HasMaxLength(15)
                .HasColumnName("CON_Movil");
            entity.Property(e => e.ConNombre)
                .HasMaxLength(150)
                .HasColumnName("CON_Nombre");
            entity.Property(e => e.ConObs)
                .HasMaxLength(255)
                .HasColumnName("CON_Obs");
            entity.Property(e => e.ConTelf)
                .HasMaxLength(15)
                .HasColumnName("CON_Telf");
        });

        modelBuilder.Entity<ContadoresFacTrebol>(entity =>
        {
            entity.HasKey(e => new { e.SocId, e.TstId, e.CntEjercicio });

            entity.ToTable("ContadoresFacTrebol");

            entity.Property(e => e.SocId).HasColumnName("SOC_ID");
            entity.Property(e => e.TstId).HasColumnName("TST_ID");
            entity.Property(e => e.CntEjercicio).HasColumnName("CNT_Ejercicio");
            entity.Property(e => e.CntNumAbono).HasColumnName("CNT_NumAbono");
            entity.Property(e => e.CntNumDoc).HasColumnName("CNT_NumDoc");
            entity.Property(e => e.CntSerie)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNT_Serie");
            entity.Property(e => e.CntSerieAbono)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNT_SerieAbono");
            entity.Property(e => e.CntSerieProForma)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNT_SerieProForma");

            entity.HasOne(d => d.Soc).WithMany(p => p.ContadoresFacTrebols)
                .HasForeignKey(d => d.SocId)
                .HasConstraintName("FK_ContadoresFacTrebol_Sociedades");

            entity.HasOne(d => d.Tst).WithMany(p => p.ContadoresFacTrebols)
                .HasForeignKey(d => d.TstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContadoresFacTrebol_TipoServiciosTrebol");
        });

        modelBuilder.Entity<ContadoresLotesEnvio>(entity =>
        {
            entity.HasKey(e => e.UnnId).HasName("PK_ConfiguracionFidelizacion_1");

            entity.Property(e => e.UnnId)
                .ValueGeneratedNever()
                .HasColumnName("UNN_ID");
            entity.Property(e => e.ConLotesDocum).HasColumnName("CON_LotesDocum");
            entity.Property(e => e.ConLotesTarjetas).HasColumnName("CON_LotesTarjetas");

            entity.HasOne(d => d.Unn).WithOne(p => p.ContadoresLotesEnvio)
                .HasForeignKey<ContadoresLotesEnvio>(d => d.UnnId)
                .HasConstraintName("FK_ConfiguracionFidelizacion_UnidadesNegocio");
        });

        modelBuilder.Entity<ContadoresPnf>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.CpcEjercicio, e.DptId });

            entity.ToTable("ContadoresPNF");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.CpcEjercicio).HasColumnName("CPC_Ejercicio");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");
            entity.Property(e => e.CpcContador).HasColumnName("CPC_Contador");

            entity.HasOne(d => d.Dpt).WithMany(p => p.ContadoresPnfs)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContadoresPNF_Departamentos");
        });

        modelBuilder.Entity<ConvTiposVia>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Conv_TiposVias");

            entity.Property(e => e.ConTipoVia)
                .HasMaxLength(100)
                .HasColumnName("CON_TipoVia");
            entity.Property(e => e.TpvId).HasColumnName("TPV_ID");
        });

        modelBuilder.Entity<ConvUsuvefrel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Conv_USUVEFRel");

            entity.Property(e => e.TicFarmacia).HasMaxLength(20);
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UsuId).HasMaxLength(100);
            entity.Property(e => e.UsuId1).HasColumnName("USU_ID");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.CueId);

            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.CueBonos).HasColumnName("CUE_Bonos");
            entity.Property(e => e.CueBonosImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUE_BonosImporte");
            entity.Property(e => e.CueFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("CUE_FModificacion");
            entity.Property(e => e.CueImpBonificacion)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUE_ImpBonificacion");
            entity.Property(e => e.CuePuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUE_Puntos");
            entity.Property(e => e.CueUmodificacion)
                .HasMaxLength(50)
                .HasColumnName("CUE_UModificacion");
        });

        modelBuilder.Entity<CuentasBono>(entity =>
        {
            entity.HasKey(e => new { e.CueId, e.ArtCodigo, e.CubId }).HasName("PK_CuentasBonos_1");

            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.CubId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUB_ID");
            entity.Property(e => e.CubFechaCaducidad)
                .HasColumnType("datetime")
                .HasColumnName("CUB_FechaCaducidad");
            entity.Property(e => e.CubFechaUso)
                .HasColumnType("datetime")
                .HasColumnName("CUB_FechaUso");
            entity.Property(e => e.CubUsado).HasColumnName("CUB_Usado");
            entity.Property(e => e.CubUsoForzado).HasColumnName("CUB_UsoForzado");
            entity.Property(e => e.TarId)
                .HasMaxLength(13)
                .HasColumnName("TAR_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UsuId).HasColumnName("USU_ID");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");

            entity.HasOne(d => d.Cue).WithMany(p => p.CuentasBonos)
                .HasForeignKey(d => d.CueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentasBonos_Cuentas");
        });

        modelBuilder.Entity<CuentasDetalle>(entity =>
        {
            entity.HasKey(e => new { e.CudId, e.CueId });

            entity.ToTable("CuentasDetalle");

            entity.HasIndex(e => new { e.UnnId, e.CudFalta }, "IX_CuentasDetalle");

            entity.HasIndex(e => new { e.UnnId, e.CudTicket }, "IX_CuentasDetalle_1");

            entity.Property(e => e.CudId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUD_ID");
            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.ArtBono)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Bono");
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CudAnulado).HasColumnName("CUD_Anulado");
            entity.Property(e => e.CudBono).HasColumnName("CUD_Bono");
            entity.Property(e => e.CudFalta)
                .HasColumnType("datetime")
                .HasColumnName("CUD_FAlta");
            entity.Property(e => e.CudFecha)
                .HasColumnType("datetime")
                .HasColumnName("CUD_Fecha");
            entity.Property(e => e.CudFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("CUD_FModificacion");
            entity.Property(e => e.CudForzado).HasColumnName("CUD_Forzado");
            entity.Property(e => e.CudHistorico).HasColumnName("CUD_Historico");
            entity.Property(e => e.CudImporteBonificable)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUD_ImporteBonificable");
            entity.Property(e => e.CudImporteBruto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUD_ImporteBruto");
            entity.Property(e => e.CudOperacion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CUD_Operacion");
            entity.Property(e => e.CudPuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUD_Puntos");
            entity.Property(e => e.CudTicket)
                .HasMaxLength(50)
                .HasColumnName("CUD_Ticket");
            entity.Property(e => e.CudUalta).HasColumnName("CUD_UAlta");
            entity.Property(e => e.CudUmodificacion).HasColumnName("CUD_UModificacion");
            entity.Property(e => e.MotId).HasColumnName("MOT_ID");
            entity.Property(e => e.TarId)
                .HasMaxLength(13)
                .HasColumnName("TAR_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");

            entity.HasOne(d => d.Cue).WithMany(p => p.CuentasDetalles)
                .HasForeignKey(d => d.CueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentasDetalle_Cuentas");

            entity.HasOne(d => d.Mot).WithMany(p => p.CuentasDetalles)
                .HasForeignKey(d => d.MotId)
                .HasConstraintName("FK_CuentasDetalle_MotivosCuentasDetalle");
        });

        modelBuilder.Entity<CuentasDetalleArticulo>(entity =>
        {
            entity.HasKey(e => new { e.CudId, e.CdaLinea });

            entity.Property(e => e.CudId).HasColumnName("CUD_ID");
            entity.Property(e => e.CdaLinea).HasColumnName("CDA_Linea");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.CdaCantidad).HasColumnName("CDA_Cantidad");
            entity.Property(e => e.CdaImporteBonif)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CDA_ImporteBonif");
            entity.Property(e => e.CdaImporteVenta)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CDA_ImporteVenta");
            entity.Property(e => e.CdaPuntos)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CDA_Puntos");
            entity.Property(e => e.CdaTipoAportacion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CDA_TipoAportacion");
        });

        modelBuilder.Entity<CuentasDetalleHistorico>(entity =>
        {
            entity.HasKey(e => new { e.CueId, e.UnnId, e.CuhMes, e.CuhAnio }).HasName("PK_CuentasDetalleHistorico_1");

            entity.ToTable("CuentasDetalleHistorico");

            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.CuhMes).HasColumnName("CUH_Mes");
            entity.Property(e => e.CuhAnio).HasColumnName("CUH_Anio");
            entity.Property(e => e.CuhBonos).HasColumnName("CUH_Bonos");
            entity.Property(e => e.CuhBonosCanjeImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_BonosCanjeImporte");
            entity.Property(e => e.CuhBonosCanjeados).HasColumnName("CUH_BonosCanjeados");
            entity.Property(e => e.CuhBonosImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_BonosImporte");
            entity.Property(e => e.CuhImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_Importe");
            entity.Property(e => e.CuhImporteBonificable)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_ImporteBonificable");
            entity.Property(e => e.CuhNumOperaciones).HasColumnName("CUH_NumOperaciones");
            entity.Property(e => e.CuhPuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_Puntos");

            entity.HasOne(d => d.Cue).WithMany(p => p.CuentasDetalleHistoricos)
                .HasForeignKey(d => d.CueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentasDetalleHistorico_Cuentas");
        });

        modelBuilder.Entity<CuentasDetalleHistoricoAntesRegeneracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CuentasDetalleHistorico_AntesRegeneracion");

            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.CuhAnio).HasColumnName("CUH_Anio");
            entity.Property(e => e.CuhBonos).HasColumnName("CUH_Bonos");
            entity.Property(e => e.CuhBonosCanjeImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_BonosCanjeImporte");
            entity.Property(e => e.CuhBonosCanjeados).HasColumnName("CUH_BonosCanjeados");
            entity.Property(e => e.CuhBonosImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_BonosImporte");
            entity.Property(e => e.CuhImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_Importe");
            entity.Property(e => e.CuhImporteBonificable)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_ImporteBonificable");
            entity.Property(e => e.CuhMes).HasColumnName("CUH_Mes");
            entity.Property(e => e.CuhNumOperaciones).HasColumnName("CUH_NumOperaciones");
            entity.Property(e => e.CuhPuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUH_Puntos");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DptId);

            entity.Property(e => e.DptId).HasColumnName("DPT_ID");
            entity.Property(e => e.DptAbrv)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DPT_Abrv");
            entity.Property(e => e.DptNombre)
                .HasMaxLength(50)
                .HasColumnName("DPT_Nombre");
            entity.Property(e => e.DptTrebol).HasColumnName("DPT_Trebol");
        });

        modelBuilder.Entity<DescripcionArticuloErp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DescripcionArticuloERP");

            entity.Property(e => e.DescArticuAntiguo).HasMaxLength(100);
            entity.Property(e => e.DescArticuNuevo).HasMaxLength(100);
            entity.Property(e => e.DescLaboratorio).HasMaxLength(100);
            entity.Property(e => e.DescPlataforma).HasMaxLength(100);
            entity.Property(e => e.DescTipoIva).HasMaxLength(50);
            entity.Property(e => e.FechaInserccion).HasColumnType("datetime");
            entity.Property(e => e.IdCodigoArticu)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DescripcionIvaerp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DescripcionIVAERP");

            entity.Property(e => e.DescIvaantiguo)
                .HasMaxLength(100)
                .HasColumnName("DescIVAAntiguo");
            entity.Property(e => e.DescIvanuevo)
                .HasMaxLength(100)
                .HasColumnName("DescIVANuevo");
            entity.Property(e => e.FechaInserccion).HasColumnType("datetime");
            entity.Property(e => e.IdCodigoArticu)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IdIvaantiguo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idIVAAntiguo");
            entity.Property(e => e.IdIvanuevo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idIVANuevo");
        });

        modelBuilder.Entity<DiferenciaErpfarmatic>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DiferenciaERPFarmatic");

            entity.Property(e => e.Erpvendedor)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ERPVENDEDOR");
            entity.Property(e => e.Farmacia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FARMACIA");
            entity.Property(e => e.Farmaticvendedor)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FARMATICVENDEDOR");
            entity.Property(e => e.Idfarmacia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDFARMACIA");
            entity.Property(e => e.Nombreerp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREERP");
            entity.Property(e => e.Nombrefarmatic)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREFARMATIC");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.DirId);

            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.DirCodPostal)
                .HasMaxLength(15)
                .HasColumnName("DIR_CodPostal");
            entity.Property(e => e.DirComplemento)
                .HasMaxLength(255)
                .HasColumnName("DIR_Complemento");
            entity.Property(e => e.DirEscalera)
                .HasMaxLength(10)
                .HasColumnName("DIR_Escalera");
            entity.Property(e => e.DirNombreCalle)
                .HasMaxLength(255)
                .HasColumnName("DIR_NombreCalle");
            entity.Property(e => e.DirNumero)
                .HasMaxLength(10)
                .HasColumnName("DIR_Numero");
            entity.Property(e => e.DirPiso)
                .HasMaxLength(10)
                .HasColumnName("DIR_Piso");
            entity.Property(e => e.DirPortal)
                .HasMaxLength(10)
                .HasColumnName("DIR_Portal");
            entity.Property(e => e.DirPuerta)
                .HasMaxLength(10)
                .HasColumnName("Dir_Puerta");
            entity.Property(e => e.PobId).HasColumnName("POB_ID");
            entity.Property(e => e.PrvId).HasColumnName("PRV_ID");
            entity.Property(e => e.TviId).HasColumnName("TVI_ID");

            entity.HasOne(d => d.Poblacion).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.PobId)
                .HasConstraintName("FK_Direcciones_Poblaciones");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.PrvId);

            entity.HasOne(d => d.TipoVia).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.TviId)
                .HasConstraintName("FK_Direcciones_TiposVial");
        });

        modelBuilder.Entity<DocumentosLopd>(entity =>
        {
            entity.HasKey(e => e.DocId);

            entity.ToTable("DocumentosLOPD");

            entity.Property(e => e.DocId).HasColumnName("DOC_ID");
            entity.Property(e => e.DocDescripcion)
                .HasMaxLength(255)
                .HasColumnName("DOC_Descripcion");
            entity.Property(e => e.DocFalta)
                .HasColumnType("datetime")
                .HasColumnName("DOC_FAlta");
            entity.Property(e => e.DocFfinAviso)
                .HasColumnType("datetime")
                .HasColumnName("DOC_FFinAviso");
            entity.Property(e => e.DocFmodificafcion)
                .HasColumnType("datetime")
                .HasColumnName("DOC_FModificafcion");
            entity.Property(e => e.DocUalta).HasColumnName("DOC_UAlta");
            entity.Property(e => e.DocUmodificacion).HasColumnName("DOC_UModificacion");

            entity.HasMany(d => d.Clis).WithMany(p => p.Docs)
                .UsingEntity<Dictionary<string, object>>(
                    "DocumentosLopdcliente",
                    r => r.HasOne<Cliente>().WithMany()
                        .HasForeignKey("CliId")
                        .HasConstraintName("FK_DocumentosLOPDClientes_Clientes"),
                    l => l.HasOne<DocumentosLopd>().WithMany()
                        .HasForeignKey("DocId")
                        .HasConstraintName("FK_DocumentosLOPDClientes_DocumentosLOPD"),
                    j =>
                    {
                        j.HasKey("DocId", "CliId");
                        j.ToTable("DocumentosLOPDClientes");
                        j.IndexerProperty<int>("DocId").HasColumnName("DOC_ID");
                        j.IndexerProperty<int>("CliId").HasColumnName("CLI_ID");
                    });

            entity.HasMany(d => d.Tats).WithMany(p => p.Docs)
                .UsingEntity<Dictionary<string, object>>(
                    "DocumentosLopdtiposTarjeta",
                    r => r.HasOne<TarjetasTipo>().WithMany()
                        .HasForeignKey("TatId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_DocumentosLOPDTiposTarjetas_TarjetasTipos"),
                    l => l.HasOne<DocumentosLopd>().WithMany()
                        .HasForeignKey("DocId")
                        .HasConstraintName("FK_DocumentosLOPDTiposTarjetas_DocumentosLOPD"),
                    j =>
                    {
                        j.HasKey("DocId", "TatId");
                        j.ToTable("DocumentosLOPDTiposTarjetas");
                        j.IndexerProperty<int>("DocId").HasColumnName("DOC_ID");
                        j.IndexerProperty<int>("TatId").HasColumnName("TAT_ID");
                    });
        });

        modelBuilder.Entity<Emedefinicion>(entity =>
        {
            entity.HasKey(e => new { e.EmeArtInicio, e.EmeArtFin });

            entity.ToTable("EMEDefinicion");

            entity.Property(e => e.EmeArtInicio)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EME_ArtInicio");
            entity.Property(e => e.EmeArtFin)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EME_ArtFin");
            entity.Property(e => e.EmePrecio)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("EME_Precio");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.Property(e => e.EmpId).HasColumnName("EMP_ID");
            entity.Property(e => e.CatId).HasColumnName("CAT_ID");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.EmpApellido1)
                .HasMaxLength(150)
                .HasColumnName("EMP_Apellido1");
            entity.Property(e => e.EmpApellido2)
                .HasMaxLength(150)
                .HasColumnName("EMP_Apellido2");
            entity.Property(e => e.EmpEstado).HasColumnName("EMP_Estado");
            entity.Property(e => e.EmpFalta)
                .HasComment("Fecha de Alta")
                .HasColumnType("datetime")
                .HasColumnName("EMP_FAlta");
            entity.Property(e => e.EmpFmodificacion)
                .HasComment("Fecha Modificación")
                .HasColumnType("datetime")
                .HasColumnName("EMP_FModificacion");
            entity.Property(e => e.EmpFoto)
                .HasMaxLength(255)
                .HasColumnName("EMP_Foto");
            entity.Property(e => e.EmpIdfiscal)
                .HasMaxLength(15)
                .HasColumnName("EMP_IDFiscal");
            entity.Property(e => e.EmpMail)
                .HasMaxLength(255)
                .HasColumnName("EMP_Mail");
            entity.Property(e => e.EmpNombre)
                .HasMaxLength(150)
                .HasColumnName("EMP_Nombre");
            entity.Property(e => e.EmpTelf)
                .HasMaxLength(15)
                .HasColumnName("EMP_Telf");
            entity.Property(e => e.EmpUalta)
                .HasComment("Id. Usuario Alta")
                .HasColumnName("EMP_UAlta");
            entity.Property(e => e.EmpUmodificacion)
                .HasComment("Identificador del último Usuario que modificó")
                .HasColumnName("EMP_UModificacion");
            entity.Property(e => e.EmpUsrId).HasColumnName("EMP_UsrID");

            entity.HasOne(d => d.Dir).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DirId)
                .HasConstraintName("FK_Empleados_Direcciones");

            entity.HasOne(d => d.EmpUsr).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.EmpUsrId)
                .HasConstraintName("FK_Empleados_Usuarios");
        });

        modelBuilder.Entity<EmpleadosDocumento>(entity =>
        {
            entity.HasKey(e => e.EdoId);

            entity.HasIndex(e => e.EmpId, "IX_EmpleadosDocumentos");

            entity.Property(e => e.EdoId).HasColumnName("EDO_ID");
            entity.Property(e => e.EdoDescrip)
                .HasMaxLength(150)
                .HasColumnName("EDO_Descrip");
            entity.Property(e => e.EdoLink)
                .HasMaxLength(255)
                .HasColumnName("EDO_Link");
            entity.Property(e => e.EmpId).HasColumnName("EMP_ID");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmpleadosDocumentos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpleadosDocumentos_Empleados");
        });

        modelBuilder.Entity<EmpleadoUnidadNegocio>(entity =>
        {
            entity.HasKey(e => new { e.EmpId, e.UnnId });

            entity.ToTable("EmpleadosUnidadesNeg");

            entity.Property(e => e.EmpId).HasColumnName("EMP_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.EmpMail)
                .HasMaxLength(255)
                .HasColumnName("EMP_Mail");
            entity.Property(e => e.EmpTelef)
                .HasMaxLength(15)
                .HasColumnName("EMP_Telef");
            entity.Property(e => e.UnnUltima).HasColumnName("UNN_Ultima");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");
            entity.Property(e => e.VefIdgenerico).HasColumnName("VEF_IDGenerico");

            entity.HasOne(d => d.Empleado).WithMany(p => p.EmpleadosUnidadesNegs)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmpleadosUnidadesNeg_Empleados");

            entity.HasOne(d => d.UnidadNegocio).WithMany(p => p.EmpleadoUnidadesNegocio)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_EmpleadosUnidadesNeg_UnidadesNegocio");
        });

        modelBuilder.Entity<EmpleadoUnidadNegRole>(entity =>
        {
            entity.HasKey(e => new { e.EmpId, e.UnnId, e.RolId });

            entity.Property(e => e.EmpId).HasColumnName("EMP_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.RolId).HasColumnName("ROL_ID");
            entity.Property(e => e.EmpFasignado)
                .HasColumnType("datetime")
                .HasColumnName("EMP_FAsignado");
            entity.Property(e => e.EmpFbaja)
                .HasColumnType("datetime")
                .HasColumnName("EMP_FBaja");
            entity.Property(e => e.EmpMotivoBaja)
                .HasMaxLength(4000)
                .HasColumnName("EMP_MotivoBaja");

            entity.HasOne(d => d.Rol).WithMany(p => p.EmpleadosUnidadesNegRoles)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpleadosUnidadesNegRoles_RolesEmpleados");

            entity.HasOne(d => d.EmpleadoUnidadNeg).WithMany(p => p.EmpleadoUnidadNegRoles)
                .HasForeignKey(d => new { d.EmpId, d.UnnId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmpleadosUnidadesNegRoles_EmpleadosUnidadesNeg");
        });

        modelBuilder.Entity<EnviosFormulario>(entity =>
        {
            entity.HasKey(e => e.EnvId).HasName("PK_Envios");

            entity.HasIndex(e => new { e.UnnId, e.EnvLote }, "IX_EnviosFormularios");

            entity.Property(e => e.EnvId).HasColumnName("ENV_ID");
            entity.Property(e => e.EnvFalta)
                .HasColumnType("datetime")
                .HasColumnName("ENV_FAlta");
            entity.Property(e => e.EnvLote).HasColumnName("ENV_Lote");
            entity.Property(e => e.EnvTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ENV_Tipo");
            entity.Property(e => e.EnvUalta).HasColumnName("ENV_UAlta");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");

            entity.HasOne(d => d.Unn).WithMany(p => p.EnviosFormularios)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_EnviosFormularios_UnidadesNegocio");
        });

        modelBuilder.Entity<EnviosFormulariosLinea>(entity =>
        {
            entity.HasKey(e => new { e.EnvId, e.EnvLinea });

            entity.Property(e => e.EnvId).HasColumnName("ENV_ID");
            entity.Property(e => e.EnvLinea).HasColumnName("ENV_Linea");
            entity.Property(e => e.ForCodBar)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FOR_CodBar");

            entity.HasOne(d => d.Env).WithMany(p => p.EnviosFormulariosLineas)
                .HasForeignKey(d => d.EnvId)
                .HasConstraintName("FK_EnviosFormulariosLineas_EnviosFormularios");
        });

        modelBuilder.Entity<FacturasTrebol>(entity =>
        {
            entity.HasKey(e => e.FtrId);

            entity.ToTable("FacturasTrebol");

            entity.Property(e => e.FtrId).HasColumnName("FTR_ID");
            entity.Property(e => e.BanCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BAN_Codigo");
            entity.Property(e => e.CccCodigo)
                .HasMaxLength(12)
                .HasColumnName("CCC_Codigo");
            entity.Property(e => e.CccIban)
                .HasMaxLength(34)
                .HasColumnName("CCC_IBAN");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.FtrAbonada).HasColumnName("FTR_Abonada");
            entity.Property(e => e.FtrBaseImponible)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTR_BaseImponible");
            entity.Property(e => e.FtrCopias).HasColumnName("FTR_Copias");
            entity.Property(e => e.FtrCuotas)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTR_Cuotas");
            entity.Property(e => e.FtrEjercicio).HasColumnName("FTR_Ejercicio");
            entity.Property(e => e.FtrFecha)
                .HasColumnType("datetime")
                .HasColumnName("FTR_Fecha");
            entity.Property(e => e.FtrFechaVenc)
                .HasColumnType("datetime")
                .HasColumnName("FTR_FechaVenc");
            entity.Property(e => e.FtrIdabono).HasColumnName("FTR_IDAbono");
            entity.Property(e => e.FtrMes).HasColumnName("FTR_Mes");
            entity.Property(e => e.FtrNumDoc)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FTR_NumDoc");
            entity.Property(e => e.FtrProforma).HasColumnName("FTR_Proforma");
            entity.Property(e => e.FtrRefExterna)
                .HasMaxLength(25)
                .HasColumnName("FTR_RefExterna");
            entity.Property(e => e.FtrTotal)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTR_Total");
            entity.Property(e => e.FtrVerResumida).HasColumnName("FTR_VerResumida");
            entity.Property(e => e.ParIdcliente).HasColumnName("PAR_IDCliente");
            entity.Property(e => e.SocId).HasColumnName("SOC_ID");
            entity.Property(e => e.SocIdcliente).HasColumnName("SOC_IDCliente");
            entity.Property(e => e.SucCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SUC_Codigo");
            entity.Property(e => e.TftId).HasColumnName("TFT_ID");
            entity.Property(e => e.TstId).HasColumnName("TST_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UnnIdcliente).HasColumnName("UNN_IDCliente");

            entity.HasOne(d => d.Fpa).WithMany(p => p.FacturasTrebols)
                .HasForeignKey(d => d.FpaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturasTrebol_FormasPago");

            entity.HasOne(d => d.FtrIdabonoNavigation).WithMany(p => p.InverseFtrIdabonoNavigation)
                .HasForeignKey(d => d.FtrIdabono)
                .HasConstraintName("FK_FacturasTrebol_FacturasTrebol");

            entity.HasOne(d => d.Tst).WithMany(p => p.FacturasTrebols)
                .HasForeignKey(d => d.TstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturasTrebol_TipoServiciosTrebol");

            entity.HasMany(d => d.Recs).WithMany(p => p.Ftrs)
                .UsingEntity<Dictionary<string, object>>(
                    "FacturasTrebolRelTraspaso",
                    r => r.HasOne<Fttraspaso>().WithMany()
                        .HasForeignKey("RecId")
                        .HasConstraintName("FK_FacturasTrebolRelTraspasos_FTTraspasos"),
                    l => l.HasOne<FacturasTrebol>().WithMany()
                        .HasForeignKey("FtrId")
                        .HasConstraintName("FK_FacturasTrebolRelTraspasos_FacturasTrebol"),
                    j =>
                    {
                        j.HasKey("FtrId", "RecId");
                        j.ToTable("FacturasTrebolRelTraspasos");
                        j.IndexerProperty<int>("FtrId").HasColumnName("FTR_ID");
                        j.IndexerProperty<int>("RecId").HasColumnName("REC_ID");
                    });

            entity.HasMany(d => d.Vcps).WithMany(p => p.Ftrs)
                .UsingEntity<Dictionary<string, object>>(
                    "FacturasTrebolRelPicking",
                    r => r.HasOne<FtpickingOv>().WithMany()
                        .HasForeignKey("VcpId")
                        .HasConstraintName("FK_FacturasTrebolRelPicking_FTPickingOV"),
                    l => l.HasOne<FacturasTrebol>().WithMany()
                        .HasForeignKey("FtrId")
                        .HasConstraintName("FK_FacturasTrebolRelPicking_FacturasTrebol"),
                    j =>
                    {
                        j.HasKey("FtrId", "VcpId");
                        j.ToTable("FacturasTrebolRelPicking");
                        j.IndexerProperty<int>("FtrId").HasColumnName("FTR_ID");
                        j.IndexerProperty<int>("VcpId").HasColumnName("VCP_ID");
                    });
        });

        modelBuilder.Entity<FacturasTrebolConcepto>(entity =>
        {
            entity.HasKey(e => e.CftId);

            entity.Property(e => e.CftId).HasColumnName("CFT_ID");
            entity.Property(e => e.CftDescrip)
                .HasMaxLength(100)
                .HasColumnName("CFT_Descrip");
            entity.Property(e => e.CftImpBruto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CFT_ImpBruto");
            entity.Property(e => e.SocIdcentral).HasColumnName("SOC_IDCentral");
            entity.Property(e => e.TivId).HasColumnName("TIV_ID");
            entity.Property(e => e.TstId).HasColumnName("TST_ID");
            entity.Property(e => e.UnnIdcentral).HasColumnName("UNN_IDCentral");

            entity.HasOne(d => d.Tiv).WithMany(p => p.FacturasTrebolConceptos)
                .HasForeignKey(d => d.TivId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturasTrebolConceptos_TiposIVA");

            entity.HasOne(d => d.Tst).WithMany(p => p.FacturasTrebolConceptos)
                .HasForeignKey(d => d.TstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturasTrebolConceptos_TipoServiciosTrebol");

            entity.HasOne(d => d.UnidadesNegocioSoc).WithMany(p => p.FacturasTrebolConceptos)
                .HasForeignKey(d => new { d.UnnIdcentral, d.SocIdcentral })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturasTrebolConceptos_UnidadesNegocioSoc");
        });

        modelBuilder.Entity<FacturasTrebolConceptosUnn>(entity =>
        {
            entity.HasKey(e => new { e.CftId, e.UnnId });

            entity.ToTable("FacturasTrebolConceptosUNN");

            entity.Property(e => e.CftId).HasColumnName("CFT_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.CftImpBruto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CFT_ImpBruto");
            entity.Property(e => e.CftNoAplicar).HasColumnName("CFT_NoAplicar");

            entity.HasOne(d => d.Cft).WithMany(p => p.FacturasTrebolConceptosUnns)
                .HasForeignKey(d => d.CftId)
                .HasConstraintName("FK_FacturasTrebolConceptosUNN_FacturasTrebolConceptos");

            entity.HasOne(d => d.Unn).WithMany(p => p.FacturasTrebolConceptosUnns)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_FacturasTrebolConceptosUNN_UnidadesNegocio");
        });

        modelBuilder.Entity<FacturasTrebolLinea>(entity =>
        {
            entity.HasKey(e => new { e.FtrId, e.FtlNumLinea });

            entity.Property(e => e.FtrId).HasColumnName("FTR_ID");
            entity.Property(e => e.FtlNumLinea).HasColumnName("FTL_NumLinea");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtFamilia).HasColumnName("ART_Familia");
            entity.Property(e => e.CftId).HasColumnName("CFT_ID");
            entity.Property(e => e.FacIdLinea).HasColumnName("FAC_IdLinea");
            entity.Property(e => e.FacNumDoc)
                .HasMaxLength(13)
                .HasColumnName("FAC_NumDoc");
            entity.Property(e => e.FtlBaseCalculo)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTL_BaseCalculo");
            entity.Property(e => e.FtlBaseImponible)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTL_BaseImponible");
            entity.Property(e => e.FtlCuota)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTL_Cuota");
            entity.Property(e => e.FtlDescripcion)
                .HasMaxLength(100)
                .HasColumnName("FTL_Descripcion");
            entity.Property(e => e.FtlPorCalculo)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("FTL_PorCalculo");
            entity.Property(e => e.FtlPorImpuesto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("FTL_PorImpuesto");
            entity.Property(e => e.FtlPrecio)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTL_Precio");
            entity.Property(e => e.FtlResumir).HasColumnName("FTL_Resumir");
            entity.Property(e => e.FtlTipoLinea)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FTL_TipoLInea");
            entity.Property(e => e.FtlTotalLinea)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTL_TotalLinea");
            entity.Property(e => e.FtlUnidades).HasColumnName("FTL_Unidades");
            entity.Property(e => e.FtlValorMinimo).HasColumnName("FTL_ValorMinimo");

            entity.HasOne(d => d.Ftr).WithMany(p => p.FacturasTrebolLineas)
                .HasForeignKey(d => d.FtrId)
                .HasConstraintName("FK_FacturasTrebolLineas_FacturasTrebol");

            entity.HasMany(d => d.Fsls).WithMany(p => p.FacturasTrebolLineas)
                .UsingEntity<Dictionary<string, object>>(
                    "FacturasTrebolRelFactss",
                    r => r.HasOne<TssfacturasClientesLinea>().WithMany()
                        .HasForeignKey("FslId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FacturasTrebolRelFACTSS_TSSFacturasClientesLineas"),
                    l => l.HasOne<FacturasTrebolLinea>().WithMany()
                        .HasForeignKey("FtrId", "FtlNumLinea")
                        .HasConstraintName("FK_FacturasTrebolRelFACTSS_FacturasTrebolLineas"),
                    j =>
                    {
                        j.HasKey("FtrId", "FtlNumLinea", "FslId");
                        j.ToTable("FacturasTrebolRelFACTSS");
                        j.IndexerProperty<int>("FtrId").HasColumnName("FTR_ID");
                        j.IndexerProperty<int>("FtlNumLinea").HasColumnName("FTL_NumLinea");
                        j.IndexerProperty<int>("FslId").HasColumnName("FSL_ID");
                    });

            entity.HasMany(d => d.Plus).WithMany(p => p.FacturasTrebolLineas)
                .UsingEntity<Dictionary<string, object>>(
                    "FacturasTrebolRelPnf",
                    r => r.HasOne<PedidosNflineasUnn>().WithMany()
                        .HasForeignKey("PluId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FacturasTrebolRelPNF_PedidosNFLineasUNN"),
                    l => l.HasOne<FacturasTrebolLinea>().WithMany()
                        .HasForeignKey("FtrId", "FtlNumLinea")
                        .HasConstraintName("FK_FacturasTrebolRelPNF_FacturasTrebolLineasPNFUNN"),
                    j =>
                    {
                        j.HasKey("FtrId", "FtlNumLinea", "PluId").HasName("PK_FacturasTrebolRelPNF_1");
                        j.ToTable("FacturasTrebolRelPNF");
                        j.IndexerProperty<int>("FtrId").HasColumnName("FTR_ID");
                        j.IndexerProperty<int>("FtlNumLinea").HasColumnName("FTL_NumLinea");
                        j.IndexerProperty<int>("PluId").HasColumnName("PLU_ID");
                    });
        });

        modelBuilder.Entity<FacturasTrebolLineasBase>(entity =>
        {
            entity.HasKey(e => new { e.FtrId, e.FlbLinea });

            entity.ToTable("FacturasTrebolLineasBase");

            entity.Property(e => e.FtrId).HasColumnName("FTR_ID");
            entity.Property(e => e.FlbLinea).HasColumnName("FLB_Linea");
            entity.Property(e => e.FlbDescripcion)
                .HasMaxLength(100)
                .HasColumnName("FLB_Descripcion");
            entity.Property(e => e.FlbImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FLB_Importe");

            entity.HasOne(d => d.Ftr).WithMany(p => p.FacturasTrebolLineasBases)
                .HasForeignKey(d => d.FtrId)
                .HasConstraintName("FK_FacturasTrebolLineasBase_FacturasTrebol");
        });

        modelBuilder.Entity<FacturasTrebolResumenLin>(entity =>
        {
            entity.HasKey(e => new { e.FtrId, e.FtrPorImpuesto });

            entity.ToTable("FacturasTrebolResumenLin");

            entity.Property(e => e.FtrId).HasColumnName("FTR_ID");
            entity.Property(e => e.FtrPorImpuesto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("FTR_PorImpuesto");
            entity.Property(e => e.FtrBase)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTR_Base");
            entity.Property(e => e.FtrCuota)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTR_Cuota");
            entity.Property(e => e.FtrTextoResumen)
                .HasMaxLength(255)
                .HasColumnName("FTR_TextoResumen");
            entity.Property(e => e.FtrTotal)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTR_Total");

            entity.HasOne(d => d.Ftr).WithMany(p => p.FacturasTrebolResumenLins)
                .HasForeignKey(d => d.FtrId)
                .HasConstraintName("FK_FacturasTrebolResumenLin_FacturasTrebol");
        });

        modelBuilder.Entity<FacturasTrebolTexto>(entity =>
        {
            entity.HasKey(e => e.TftId);

            entity.Property(e => e.TftId).HasColumnName("TFT_ID");
            entity.Property(e => e.SocId).HasColumnName("SOC_ID");
            entity.Property(e => e.TftActivo).HasColumnName("TFT_Activo");
            entity.Property(e => e.TftDescrip)
                .HasMaxLength(50)
                .HasColumnName("TFT_Descrip");
            entity.Property(e => e.TftTexto)
                .HasMaxLength(500)
                .HasColumnName("TFT_Texto");

            entity.HasOne(d => d.Soc).WithMany(p => p.FacturasTrebolTextos)
                .HasForeignKey(d => d.SocId)
                .HasConstraintName("FK_FacturasTrebolTextos_Sociedades");
        });

        modelBuilder.Entity<FormasPago>(entity =>
        {
            entity.HasKey(e => e.FpaId);

            entity.ToTable("FormasPago");

            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.FpaCliente).HasColumnName("FPA_Cliente");
            entity.Property(e => e.FpaDomBanco).HasColumnName("FPA_DomBanco");
            entity.Property(e => e.FpaNombre)
                .HasMaxLength(75)
                .HasColumnName("FPA_Nombre");
            entity.Property(e => e.FpaProveedor).HasColumnName("FPA_Proveedor");
        });

        modelBuilder.Entity<FormasPagoDia>(entity =>
        {
            entity.HasKey(e => new { e.FpaId, e.FpaLinea });

            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.FpaLinea).HasColumnName("FPA_Linea");
            entity.Property(e => e.FpaDias).HasColumnName("FPA_Dias");
            entity.Property(e => e.FpaPorcentEfecto).HasColumnName("FPA_PorcentEfecto");

            entity.HasOne(d => d.Fpa).WithMany(p => p.FormasPagoDia)
                .HasForeignKey(d => d.FpaId)
                .HasConstraintName("FK_FormasPagoDias_FormasPago");
        });

        modelBuilder.Entity<Formulario>(entity =>
        {
            entity.HasKey(e => e.ForId).HasName("PK_Almacen");

            entity.Property(e => e.ForId).HasColumnName("FOR_ID");
            entity.Property(e => e.DocId).HasColumnName("DOC_ID");
            entity.Property(e => e.ForAgotadas).HasColumnName("FOR_Agotadas");
            entity.Property(e => e.ForDestino).HasColumnName("FOR_Destino");
            entity.Property(e => e.ForFalta)
                .HasColumnType("datetime")
                .HasColumnName("FOR_Falta");
            entity.Property(e => e.ForFecha)
                .HasColumnType("datetime")
                .HasColumnName("FOR_Fecha");
            entity.Property(e => e.ForFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("FOR_FModificacion");
            entity.Property(e => e.ForFormularioOrigen).HasColumnName("FOR_FormularioOrigen");
            entity.Property(e => e.ForLote).HasColumnName("FOR_Lote");
            entity.Property(e => e.ForOrigen).HasColumnName("FOR_Origen");
            entity.Property(e => e.ForRangoFin)
                .HasMaxLength(13)
                .HasColumnName("FOR_RangoFin");
            entity.Property(e => e.ForRangoInicio)
                .HasMaxLength(13)
                .HasColumnName("FOR_RangoInicio");
            entity.Property(e => e.ForRefExterna)
                .HasMaxLength(100)
                .HasColumnName("FOR_RefExterna");
            entity.Property(e => e.ForRepartida).HasColumnName("FOR_Repartida");
            entity.Property(e => e.ForTipoElemento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FOR_TipoElemento");
            entity.Property(e => e.ForTipoMovimiento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FOR_TipoMovimiento");
            entity.Property(e => e.ForUalta).HasColumnName("FOR_UAlta");
            entity.Property(e => e.ForUmodificacion).HasColumnName("FOR_UModificacion");
            entity.Property(e => e.TatId).HasColumnName("TAT_ID");

            entity.HasOne(d => d.Doc).WithMany(p => p.Formularios)
                .HasForeignKey(d => d.DocId)
                .HasConstraintName("FK_Formularios_DocumentosLOPD");

            entity.HasOne(d => d.Tat).WithMany(p => p.Formularios)
                .HasForeignKey(d => d.TatId)
                .HasConstraintName("FK_Formularios_TarjetasTipos");
        });

        modelBuilder.Entity<FormulariosAnulacion>(entity =>
        {
            entity.HasKey(e => e.FoaId).HasName("PK_AlmacenAnulacion");

            entity.ToTable("FormulariosAnulacion");

            entity.Property(e => e.FoaId).HasColumnName("FOA_ID");
            entity.Property(e => e.FoaFecha)
                .HasColumnType("datetime")
                .HasColumnName("FOA_Fecha");
            entity.Property(e => e.FoaMotivo)
                .HasMaxLength(500)
                .HasColumnName("FOA_Motivo");
            entity.Property(e => e.FoaRangoFin)
                .HasMaxLength(13)
                .HasColumnName("FOA_RangoFin");
            entity.Property(e => e.FoaRangoInicio)
                .HasMaxLength(13)
                .HasColumnName("FOA_RangoInicio");
            entity.Property(e => e.ForId).HasColumnName("FOR_ID");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");

            entity.HasOne(d => d.For).WithMany(p => p.FormulariosAnulacions)
                .HasForeignKey(d => d.ForId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormulariosAnulacion_Formularios");
        });

        modelBuilder.Entity<FtpickingOv>(entity =>
        {
            entity.HasKey(e => e.VcpId);

            entity.ToTable("FTPickingOV");

            entity.Property(e => e.VcpId).HasColumnName("VCP_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UnnIdcliente).HasColumnName("UNN_IDCliente");
            entity.Property(e => e.VenConforme).HasColumnName("VEN_Conforme");
            entity.Property(e => e.VenFacTrebol).HasColumnName("VEN_FacTrebol");
            entity.Property(e => e.VenFechaHora)
                .HasColumnType("datetime")
                .HasColumnName("VEN_FechaHora");
            entity.Property(e => e.VenId).HasColumnName("VEN_ID");
            entity.Property(e => e.VenNumDoc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VEN_NumDoc");
            entity.Property(e => e.VenTotal)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("VEN_Total");
            entity.Property(e => e.VenTotalPvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("VEN_TotalPVP");
            entity.Property(e => e.VenTotalUds).HasColumnName("VEN_TotalUds");
        });

        modelBuilder.Entity<FtpickingOvlinea>(entity =>
        {
            entity.HasKey(e => e.VclId);

            entity.ToTable("FTPickingOVLineas");

            entity.Property(e => e.VclId).HasColumnName("VCL_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtDescripcion)
                .HasMaxLength(100)
                .HasColumnName("ART_Descripcion");
            entity.Property(e => e.VcpId).HasColumnName("VCP_ID");
            entity.Property(e => e.VelConforme).HasColumnName("VEL_Conforme");
            entity.Property(e => e.VelExcluirFt).HasColumnName("VEL_ExcluirFT");
            entity.Property(e => e.VelIdlinea).HasColumnName("VEL_IDLinea");
            entity.Property(e => e.VelImportePvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("VEL_ImportePvp");
            entity.Property(e => e.VelPorcImpuestos)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("VEL_PorcImpuestos");
            entity.Property(e => e.VelPvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("VEL_Pvp");
            entity.Property(e => e.VelUnidades).HasColumnName("VEL_Unidades");

            entity.HasOne(d => d.Vcp).WithMany(p => p.FtpickingOvlineas)
                .HasForeignKey(d => d.VcpId)
                .HasConstraintName("FK_FTPickingOVLineas_FTPickingOV");
        });

        modelBuilder.Entity<FtpickingOvrecepRel>(entity =>
        {
            entity.HasKey(e => new { e.VcpId, e.RecId });

            entity.ToTable("FTPickingOVRecepRel");

            entity.Property(e => e.VcpId).HasColumnName("VCP_ID");
            entity.Property(e => e.RecId).HasColumnName("REC_ID");
            entity.Property(e => e.VcpManual).HasColumnName("VCP_Manual");

            entity.HasOne(d => d.Vcp).WithMany(p => p.FtpickingOvrecepRels)
                .HasForeignKey(d => d.VcpId)
                .HasConstraintName("FK_FTPickingOVRecepRel_FTPickingOV");
        });

        modelBuilder.Entity<Fttraspaso>(entity =>
        {
            entity.HasKey(e => e.RecId);

            entity.ToTable("FTTraspasos");

            entity.Property(e => e.RecId)
                .ValueGeneratedNever()
                .HasColumnName("REC_ID");
            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");
            entity.Property(e => e.RecFecha)
                .HasColumnType("datetime")
                .HasColumnName("REC_Fecha");
            entity.Property(e => e.RecIdFarmatic).HasColumnName("REC_IdFarmatic");
            entity.Property(e => e.RtrConforme).HasColumnName("RTR_Conforme");
            entity.Property(e => e.RtrFacturada).HasColumnName("RTR_Facturada");
            entity.Property(e => e.RtrNumDoc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RTR_NumDoc");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
        });

        modelBuilder.Entity<FttraspasosLinea>(entity =>
        {
            entity.HasKey(e => new { e.RecId, e.RelIdlinea });

            entity.ToTable("FTTraspasosLineas");

            entity.Property(e => e.RecId).HasColumnName("REC_ID");
            entity.Property(e => e.RelIdlinea).HasColumnName("REL_IDLinea");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtDescripcion)
                .HasMaxLength(100)
                .HasColumnName("ART_Descripcion");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.PvfProvHab)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_ProvHab");
            entity.Property(e => e.RelCalculoPuc).HasColumnName("REL_CalculoPUC");
            entity.Property(e => e.RelDto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("REL_DTO");
            entity.Property(e => e.RelExcluidaFt).HasColumnName("REL_ExcluidaFT");
            entity.Property(e => e.RelImpTraspaso)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("REL_ImpTraspaso");
            entity.Property(e => e.RelPuc)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("REL_PUC");
            entity.Property(e => e.RelPvl)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("REL_PVL");
            entity.Property(e => e.RelPvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("REL_PVP");
            entity.Property(e => e.RelUdsTraspaso).HasColumnName("REL_UdsTraspaso");
            entity.Property(e => e.SocId).HasColumnName("SOC_ID");
            entity.Property(e => e.TivId).HasColumnName("TIV_ID");

            entity.HasOne(d => d.Rec).WithMany(p => p.FttraspasosLineas)
                .HasForeignKey(d => d.RecId)
                .HasConstraintName("FK_FTTraspasosLineas_FTTraspasos");
        });

        modelBuilder.Entity<Generico>(entity =>
        {
            entity.HasKey(e => new { e.IdGrpGen, e.ArtCodigo });

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtEnviado).HasColumnName("ART_Enviado");
            entity.Property(e => e.ArtObservacion)
                .HasMaxLength(255)
                .HasColumnName("ART_Observacion");
            entity.Property(e => e.ArtPreferido).HasColumnName("ART_Preferido");
        });

        modelBuilder.Entity<GenericosSeleccion>(entity =>
        {
            entity.HasKey(e => new { e.IdGrpGen, e.ArtCodigo, e.UsrId });

            entity.ToTable("GenericosSeleccion");

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");

            entity.HasOne(d => d.Generico).WithMany(p => p.GenericosSeleccions)
                .HasForeignKey(d => new { d.IdGrpGen, d.ArtCodigo })
                .HasConstraintName("FK_GenericosSeleccion_Genericos");
        });

        modelBuilder.Entity<GrupoPedido>(entity =>
        {
            entity.HasKey(e => e.GpeId);

            entity.Property(e => e.GpeId).HasColumnName("GPE_ID");
            entity.Property(e => e.GpeDescrip)
                .HasMaxLength(75)
                .HasColumnName("GPE_Descrip");
        });

        modelBuilder.Entity<GruposLaboratorio>(entity =>
        {
            entity.HasKey(e => e.GlaId);

            entity.Property(e => e.GlaId).HasColumnName("GLA_ID");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.GlaFalta)
                .HasColumnType("datetime")
                .HasColumnName("GLA_FAlta");
            entity.Property(e => e.GlaFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("GLA_FModificacion");
            entity.Property(e => e.GlaIdFiscal)
                .HasMaxLength(15)
                .HasColumnName("GLA_IdFiscal");
            entity.Property(e => e.GlaNombre)
                .HasMaxLength(64)
                .HasColumnName("GLA_Nombre");
            entity.Property(e => e.GlaRevCada).HasColumnName("GLA_RevCada");
            entity.Property(e => e.GlaRevPeriodo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("M")
                .IsFixedLength()
                .HasColumnName("GLA_RevPeriodo");
            entity.Property(e => e.GlaRevUltFecha)
                .HasColumnType("datetime")
                .HasColumnName("GLA_RevUltFecha");
            entity.Property(e => e.GlaRevUsr).HasColumnName("GLA_RevUsr");
            entity.Property(e => e.GlaRevisarCc).HasColumnName("GLA_RevisarCC");
            entity.Property(e => e.GlaSoloAgrupa).HasColumnName("GLA_SoloAgrupa");
            entity.Property(e => e.GlaUalta).HasColumnName("GLA_UAlta");
            entity.Property(e => e.GlaUmodificacion).HasColumnName("GLA_UModificacion");
            entity.Property(e => e.GlaWeb)
                .HasMaxLength(255)
                .HasColumnName("GLA_Web");
        });

        modelBuilder.Entity<GruposLaboratoriosCont>(entity =>
        {
            entity.HasKey(e => new { e.GlaId, e.ConId });

            entity.Property(e => e.GlaId).HasColumnName("GLA_ID");
            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConDefecto).HasColumnName("CON_Defecto");
            entity.Property(e => e.ConPropio).HasColumnName("CON_Propio");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Con).WithMany(p => p.GruposLaboratoriosConts)
                .HasForeignKey(d => d.ConId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposLaboratoriosConts_Contactos");

            entity.HasOne(d => d.Dpt).WithMany(p => p.GruposLaboratoriosConts)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposLaboratoriosConts_Departamentos");

            entity.HasOne(d => d.Gla).WithMany(p => p.GruposLaboratoriosConts)
                .HasForeignKey(d => d.GlaId)
                .HasConstraintName("FK_GruposLaboratoriosConts_GruposLaboratorios");
        });

        modelBuilder.Entity<GruposLaboratoriosDir>(entity =>
        {
            entity.HasKey(e => new { e.GlaId, e.DirId });

            entity.Property(e => e.GlaId).HasColumnName("GLA_ID");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.DirDefecto).HasColumnName("DIR_Defecto");
            entity.Property(e => e.DirFactura).HasColumnName("DIR_Factura");
            entity.Property(e => e.DirFax1)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX1");
            entity.Property(e => e.DirFax2)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX2");
            entity.Property(e => e.DirProblemastica).HasColumnName("DIR_Problemastica");
            entity.Property(e => e.DirPropia).HasColumnName("DIR_Propia");
            entity.Property(e => e.DirTelf1)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf1");
            entity.Property(e => e.DirTelf2)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf2");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Dir).WithMany(p => p.GruposLaboratoriosDirs)
                .HasForeignKey(d => d.DirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposLaboratoriosDirs_Direcciones");

            entity.HasOne(d => d.Dpt).WithMany(p => p.GruposLaboratoriosDirs)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposLaboratoriosDirs_Departamentos");

            entity.HasOne(d => d.Gla).WithMany(p => p.GruposLaboratoriosDirs)
                .HasForeignKey(d => d.GlaId)
                .HasConstraintName("FK_GruposLaboratoriosDirs_GruposLaboratorios");
        });

        modelBuilder.Entity<GruposProveedore>(entity =>
        {
            entity.HasKey(e => e.GpvId);

            entity.Property(e => e.GpvId).HasColumnName("GPV_ID");
            entity.Property(e => e.GpvCalculoPvp).HasColumnName("GPV_CalculoPVP");
            entity.Property(e => e.GpvFalta)
                .HasColumnType("datetime")
                .HasColumnName("GPV_FAlta");
            entity.Property(e => e.GpvFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("GPV_FModificacion");
            entity.Property(e => e.GpvNombre)
                .HasMaxLength(75)
                .HasColumnName("GPV_Nombre");
            entity.Property(e => e.GpvUalta).HasColumnName("GPV_UAlta");
            entity.Property(e => e.GpvUmodificacion).HasColumnName("GPV_UModificacion");
            entity.Property(e => e.GpvWeb)
                .HasMaxLength(255)
                .HasColumnName("GPV_Web");
        });

        modelBuilder.Entity<GruposProveedoresCalculosPvp>(entity =>
        {
            entity.HasKey(e => e.CalLinId);

            entity.ToTable("GruposProveedoresCalculosPVP");

            entity.HasIndex(e => new { e.GpvId, e.TivId, e.FamId, e.GrpFacturacion }, "IX_GruposProveedoresCalculosPVP").IsUnique();

            entity.Property(e => e.CalLinId).HasColumnName("CAL_LinID");
            entity.Property(e => e.CalFactor)
                .HasColumnType("decimal(9, 3)")
                .HasColumnName("CAL_Factor");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.GpvId).HasColumnName("GPV_ID");
            entity.Property(e => e.GrpFacturacion)
                .HasMaxLength(10)
                .HasColumnName("GRP_Facturacion");
            entity.Property(e => e.TivId).HasColumnName("TIV_ID");

            entity.HasOne(d => d.Gpv).WithMany(p => p.GruposProveedoresCalculosPvps)
                .HasForeignKey(d => d.GpvId)
                .HasConstraintName("FK_GruposProveedoresCalculosPVP_GruposProveedores");

            entity.HasOne(d => d.Tiv).WithMany(p => p.GruposProveedoresCalculosPvps)
                .HasForeignKey(d => d.TivId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposProveedoresCalculosPVP_TiposIVA");
        });

        modelBuilder.Entity<GruposProveedoresCont>(entity =>
        {
            entity.HasKey(e => new { e.GpvId, e.ConId });

            entity.Property(e => e.GpvId).HasColumnName("GPV_ID");
            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConDefecto).HasColumnName("CON_Defecto");
            entity.Property(e => e.ConPropio).HasColumnName("CON_Propio");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Con).WithMany(p => p.GruposProveedoresConts)
                .HasForeignKey(d => d.ConId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposProveedoresConts_Contactos");

            entity.HasOne(d => d.Dpt).WithMany(p => p.GruposProveedoresConts)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposProveedoresConts_Departamentos");

            entity.HasOne(d => d.Gpv).WithMany(p => p.GruposProveedoresConts)
                .HasForeignKey(d => d.GpvId)
                .HasConstraintName("FK_GruposProveedoresConts_GruposProveedores");
        });

        modelBuilder.Entity<GruposProveedoresDir>(entity =>
        {
            entity.HasKey(e => new { e.GpvId, e.DirId });

            entity.Property(e => e.GpvId).HasColumnName("GPV_ID");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.DirDefecto).HasColumnName("DIR_Defecto");
            entity.Property(e => e.DirFax1)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX1");
            entity.Property(e => e.DirFax2)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX2");
            entity.Property(e => e.DirProblemastica).HasColumnName("DIR_Problemastica");
            entity.Property(e => e.DirPropia).HasColumnName("DIR_Propia");
            entity.Property(e => e.DirTelf1)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf1");
            entity.Property(e => e.DirTelf2)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf2");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Dir).WithMany(p => p.GruposProveedoresDirs)
                .HasForeignKey(d => d.DirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposProveedoresDirs_Direcciones");

            entity.HasOne(d => d.Dpt).WithMany(p => p.GruposProveedoresDirs)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GruposProveedoresDirs_Departamentos");

            entity.HasOne(d => d.Gpv).WithMany(p => p.GruposProveedoresDirs)
                .HasForeignKey(d => d.GpvId)
                .HasConstraintName("FK_GruposProveedoresDirs_GruposProveedores");
        });

        modelBuilder.Entity<HiloEjecucione>(entity =>
        {
            entity.HasKey(e => e.HilId);

            entity.Property(e => e.HilId).HasColumnName("HIL_ID");
            entity.Property(e => e.Proceso).HasMaxLength(8);
            entity.Property(e => e.UsuId).HasColumnName("USU_ID");
        });

        modelBuilder.Entity<HistoricoTarifa>(entity =>
        {
            entity.HasKey(e => e.HtrId);

            entity.HasIndex(e => new { e.ArtCodigo, e.HtrFcambio }, "IX_HistoricoTarifas");

            entity.Property(e => e.HtrId).HasColumnName("HTR_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.HtrFcambio)
                .HasColumnType("datetime")
                .HasColumnName("HTR_FCambio");
            entity.Property(e => e.HtrImpAnterior)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("HTR_ImpAnterior");
            entity.Property(e => e.HtrImpAplicar)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("HTR_ImpAplicar");
        });

        modelBuilder.Entity<IftarticulosMargenExcl>(entity =>
        {
            entity.HasKey(e => e.ArtCodigo);

            entity.ToTable("IFTArticulosMargenExcl");

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
        });

        modelBuilder.Entity<IftextraccionControl>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.OpeId, e.CexFcontrol });

            entity.ToTable("IFTExtraccionControl");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.OpeId).HasColumnName("OPE_ID");
            entity.Property(e => e.CexFcontrol)
                .HasColumnType("datetime")
                .HasColumnName("CEX_FControl");
            entity.Property(e => e.CexOk).HasColumnName("CEX_Ok");

            entity.HasOne(d => d.Ope).WithMany(p => p.IftextraccionControls)
                .HasForeignKey(d => d.OpeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IFTExtraccionControl_IFTOperacionesDefinicion");
        });

        modelBuilder.Entity<IftgrupoProceso>(entity =>
        {
            entity.HasKey(e => e.GrpId);

            entity.ToTable("IFTGrupoProceso");

            entity.Property(e => e.GrpId).HasColumnName("GRP_ID");
            entity.Property(e => e.GrpDescrip)
                .HasMaxLength(80)
                .HasColumnName("GRP_Descrip");
            entity.Property(e => e.GrpEnUsoActua).HasColumnName("GRP_EnUsoActua");
            entity.Property(e => e.GrpEnUsoExtrac).HasColumnName("GRP_EnUsoExtrac");
            entity.Property(e => e.GrpMaxLog).HasColumnName("GRP_MaxLog");

            entity.HasMany(d => d.Unns).WithMany(p => p.Grps)
                .UsingEntity<Dictionary<string, object>>(
                    "IftgruposProcesoUnidadesNeg",
                    r => r.HasOne<UnidadNegocio>().WithMany()
                        .HasForeignKey("UnnId")
                        .HasConstraintName("FK_IFTGruposProcesoUnidadesNeg_UnidadesNegocio"),
                    l => l.HasOne<IftgrupoProceso>().WithMany()
                        .HasForeignKey("GrpId")
                        .HasConstraintName("FK_IFTGruposProcesoUnidadesNeg_IFTGrupoProceso"),
                    j =>
                    {
                        j.HasKey("GrpId", "UnnId");
                        j.ToTable("IFTGruposProcesoUnidadesNeg");
                        j.IndexerProperty<int>("GrpId").HasColumnName("GRP_ID");
                        j.IndexerProperty<int>("UnnId").HasColumnName("UNN_ID");
                    });
        });

        modelBuilder.Entity<IftlogActividad>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("IFTLogActividad");

            entity.Property(e => e.LogId).HasColumnName("LOG_ID");
            entity.Property(e => e.LogDescOperacion)
                .HasMaxLength(255)
                .HasColumnName("LOG_DescOperacion");
            entity.Property(e => e.LogError)
                .HasMaxLength(500)
                .HasColumnName("LOG_Error");
            entity.Property(e => e.LogFechaHoraFin)
                .HasColumnType("datetime")
                .HasColumnName("LOG_FechaHoraFin");
            entity.Property(e => e.LogFechaHoraIni)
                .HasColumnType("datetime")
                .HasColumnName("LOG_FechaHoraIni");
            entity.Property(e => e.LogResultado).HasColumnName("LOG_Resultado");
            entity.Property(e => e.LogTipoOperacion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LOG_TipoOperacion");
            entity.Property(e => e.LogUndescrip)
                .HasMaxLength(150)
                .HasColumnName("LOG_UNDescrip");
            entity.Property(e => e.LogUsuario)
                .HasMaxLength(50)
                .HasColumnName("LOG_Usuario");
            entity.Property(e => e.OpeId).HasColumnName("OPE_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
        });

        modelBuilder.Entity<IftopActualizacionPendiente>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.OpaId });

            entity.ToTable("IFTOpActualizacionPendientes");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.OpaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("OPA_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.AuxFloat1).HasColumnName("AUX_Float1");
            entity.Property(e => e.AuxFloat2).HasColumnName("AUX_Float2");
            entity.Property(e => e.AuxInt1).HasColumnName("AUX_Int1");
            entity.Property(e => e.AuxInt2).HasColumnName("AUX_Int2");
            entity.Property(e => e.CliCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_Codigo");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.LstId).HasColumnName("LST_ID");
            entity.Property(e => e.OpaFejecutar)
                .HasColumnType("datetime")
                .HasColumnName("OPA_FEjecutar");
            entity.Property(e => e.OpeId).HasColumnName("OPE_ID");
            entity.Property(e => e.ProId)
                .HasMaxLength(8)
                .HasColumnName("PRO_ID");
            entity.Property(e => e.PrvCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRV_Codigo");
            entity.Property(e => e.SfamId).HasColumnName("SFAM_ID");
            entity.Property(e => e.TclId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_ID");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");
        });

        modelBuilder.Entity<IftopActualizacionPendientesBi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IFTOpActualizacionPendientes_BIS");

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.AuxFloat1).HasColumnName("AUX_Float1");
            entity.Property(e => e.AuxFloat2).HasColumnName("AUX_Float2");
            entity.Property(e => e.AuxInt1).HasColumnName("AUX_Int1");
            entity.Property(e => e.AuxInt2).HasColumnName("AUX_Int2");
            entity.Property(e => e.CliCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_Codigo");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.FechaInsercion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_insercion");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.LstId).HasColumnName("LST_ID");
            entity.Property(e => e.OpaFejecutar)
                .HasColumnType("datetime")
                .HasColumnName("OPA_FEjecutar");
            entity.Property(e => e.OpaId).HasColumnName("OPA_ID");
            entity.Property(e => e.OpeId).HasColumnName("OPE_ID");
            entity.Property(e => e.ProId)
                .HasMaxLength(8)
                .HasColumnName("PRO_ID");
            entity.Property(e => e.PrvCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRV_Codigo");
            entity.Property(e => e.SfamId).HasColumnName("SFAM_ID");
            entity.Property(e => e.TclId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");
        });

        modelBuilder.Entity<IftopActualizacionPendientesTri>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IFTOpActualizacionPendientes_TRIS");

            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.AuxFloat1).HasColumnName("AUX_Float1");
            entity.Property(e => e.AuxFloat2).HasColumnName("AUX_Float2");
            entity.Property(e => e.AuxInt1).HasColumnName("AUX_Int1");
            entity.Property(e => e.AuxInt2).HasColumnName("AUX_Int2");
            entity.Property(e => e.CliCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_Codigo");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.LstId).HasColumnName("LST_ID");
            entity.Property(e => e.OpaFejecutar)
                .HasColumnType("datetime")
                .HasColumnName("OPA_FEjecutar");
            entity.Property(e => e.OpaId)
                .ValueGeneratedOnAdd()
                .HasColumnName("OPA_ID");
            entity.Property(e => e.OpeId).HasColumnName("OPE_ID");
            entity.Property(e => e.ProId)
                .HasMaxLength(8)
                .HasColumnName("PRO_ID");
            entity.Property(e => e.PrvCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRV_Codigo");
            entity.Property(e => e.SfamId).HasColumnName("SFAM_ID");
            entity.Property(e => e.TclId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");
        });

        modelBuilder.Entity<IftopActualizacionResultado>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.OpaId });

            entity.ToTable("IFTOpActualizacionResultados");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.OpaId).HasColumnName("OPA_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.AuxFloat1).HasColumnName("AUX_Float1");
            entity.Property(e => e.AuxFloat2).HasColumnName("AUX_Float2");
            entity.Property(e => e.AuxInt1).HasColumnName("AUX_Int1");
            entity.Property(e => e.AuxInt2).HasColumnName("AUX_Int2");
            entity.Property(e => e.CliCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_Codigo");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.LstId).HasColumnName("LST_ID");
            entity.Property(e => e.OpaAtendida)
                .HasColumnType("datetime")
                .HasColumnName("OPA_Atendida");
            entity.Property(e => e.OpaFinclusion)
                .HasColumnType("datetime")
                .HasColumnName("OPA_FInclusion");
            entity.Property(e => e.OpaReintentos).HasColumnName("OPA_Reintentos");
            entity.Property(e => e.OpaResultado).HasColumnName("OPA_Resultado");
            entity.Property(e => e.OpeId).HasColumnName("OPE_ID");
            entity.Property(e => e.ProId)
                .HasMaxLength(8)
                .HasColumnName("PRO_ID");
            entity.Property(e => e.PrvCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRV_Codigo");
            entity.Property(e => e.SfamId).HasColumnName("SFAM_ID");
            entity.Property(e => e.TclId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_ID");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");
        });

        modelBuilder.Entity<IftopExtraccionResultado>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.OpeId }).HasName("PK_OpExtraccionResultados");

            entity.ToTable("IFTOpExtraccionResultados");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.OpeId).HasColumnName("OPE_ID");
            entity.Property(e => e.OpeAuxiliar).HasColumnName("OPE_Auxiliar");
            entity.Property(e => e.OpeControlEjec)
                .HasColumnType("datetime")
                .HasColumnName("OPE_ControlEjec");
            entity.Property(e => e.OpeInicio)
                .HasColumnType("datetime")
                .HasColumnName("OPE_Inicio");
            entity.Property(e => e.OpeUltimoResult).HasColumnName("OPE_UltimoResult");

            entity.HasOne(d => d.Ope).WithMany(p => p.IftopExtraccionResultados)
                .HasForeignKey(d => d.OpeId)
                .HasConstraintName("FK_IFTOpExtraccionResultados_IFTOperacionesDefinicion");

            entity.HasOne(d => d.Unn).WithMany(p => p.IftopExtraccionResultados)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_IFTOpExtraccionResultados_UnidadesNegocio");
        });

        modelBuilder.Entity<IftoperacionesDefinicion>(entity =>
        {
            entity.HasKey(e => e.OpeId).HasName("PK_OperacionesDefinicion");

            entity.ToTable("IFTOperacionesDefinicion");

            entity.Property(e => e.OpeId).HasColumnName("OPE_ID");
            entity.Property(e => e.OpeDescrip)
                .HasMaxLength(100)
                .HasColumnName("OPE_Descrip");
            entity.Property(e => e.OpeDia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OPE_Dia");
            entity.Property(e => e.OpeFrecuencia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OPE_Frecuencia");
            entity.Property(e => e.OpeHoraEjec)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OPE_HoraEjec");
            entity.Property(e => e.OpeInhabilitada).HasColumnName("OPE_Inhabilitada");
            entity.Property(e => e.OpeNumDia).HasColumnName("OPE_NumDia");
            entity.Property(e => e.OpeOrden).HasColumnName("OPE_Orden");
            entity.Property(e => e.OpeSentencia)
                .HasColumnType("text")
                .HasColumnName("OPE_Sentencia");
            entity.Property(e => e.OpeTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OPE_Tipo");
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.HasKey(e => e.LabCodigo);

            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.LabFalta)
                .HasColumnType("datetime")
                .HasColumnName("LAB_FAlta");
            entity.Property(e => e.LabFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("LAB_FModificacion");
            entity.Property(e => e.LabIdFiscal)
                .HasMaxLength(15)
                .HasColumnName("LAB_IdFiscal");
            entity.Property(e => e.LabNombre)
                .HasMaxLength(64)
                .HasColumnName("LAB_Nombre");
            entity.Property(e => e.LabOrigen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Origen");
            entity.Property(e => e.LabRevCada).HasColumnName("LAB_RevCada");
            entity.Property(e => e.LabRevPeriodo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_RevPeriodo");
            entity.Property(e => e.LabRevUltFecha)
                .HasColumnType("datetime")
                .HasColumnName("LAB_RevUltFecha");
            entity.Property(e => e.LabRevUsr).HasColumnName("LAB_RevUsr");
            entity.Property(e => e.LabRevisarCc).HasColumnName("LAB_RevisarCC");
            entity.Property(e => e.LabUalta).HasColumnName("LAB_UAlta");
            entity.Property(e => e.LabUmodificacion).HasColumnName("LAB_UModificacion");
            entity.Property(e => e.LabWeb)
                .HasMaxLength(255)
                .HasColumnName("LAB_web");
        });

        modelBuilder.Entity<LaboratoriosCondCompra>(entity =>
        {
            entity.HasKey(e => e.CclId);

            entity.ToTable("LaboratoriosCondCompra");

            entity.HasIndex(e => e.LabCodigo, "IX_LaboratoriosCondCompra");

            entity.Property(e => e.CclId).HasColumnName("CCL_ID");
            entity.Property(e => e.CclDesde)
                .HasColumnType("datetime")
                .HasColumnName("CCL_Desde");
            entity.Property(e => e.CclDto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CCL_Dto");
            entity.Property(e => e.CclHasta)
                .HasColumnType("datetime")
                .HasColumnName("CCL_Hasta");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.GlaId).HasColumnName("GLA_ID");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");

            entity.HasOne(d => d.Gla).WithMany(p => p.LaboratoriosCondCompras)
                .HasForeignKey(d => d.GlaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LaboratoriosCondCompra_GruposLaboratorios");

            entity.HasOne(d => d.LabCodigoNavigation).WithMany(p => p.LaboratoriosCondCompras)
                .HasForeignKey(d => d.LabCodigo)
                .HasConstraintName("FK_LaboratoriosCondCompra_Laboratorios");
        });

        modelBuilder.Entity<LaboratoriosContacto>(entity =>
        {
            entity.HasKey(e => new { e.LabCodigo, e.ConId });

            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConDefecto).HasColumnName("CON_Defecto");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Con).WithMany(p => p.LaboratoriosContactos)
                .HasForeignKey(d => d.ConId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LaboratoriosContactos_Contactos");

            entity.HasOne(d => d.Dpt).WithMany(p => p.LaboratoriosContactos)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LaboratoriosContactos_Departamentos");

            entity.HasOne(d => d.LabCodigoNavigation).WithMany(p => p.LaboratoriosContactos)
                .HasForeignKey(d => d.LabCodigo)
                .HasConstraintName("FK_LaboratoriosContactos_LaboratoriosContactos");
        });

        modelBuilder.Entity<LaboratoriosDir>(entity =>
        {
            entity.HasKey(e => new { e.LabCodigo, e.DirId });

            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.DirDefecto).HasColumnName("DIR_Defecto");
            entity.Property(e => e.DirFactura).HasColumnName("DIR_Factura");
            entity.Property(e => e.DirFax1)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX1");
            entity.Property(e => e.DirFax2)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX2");
            entity.Property(e => e.DirProblematica).HasColumnName("DIR_Problematica");
            entity.Property(e => e.DirTelf1)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf1");
            entity.Property(e => e.DirTelf2)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf2");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Dir).WithMany(p => p.LaboratoriosDirs)
                .HasForeignKey(d => d.DirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LaboratoriosDirs_Direcciones");

            entity.HasOne(d => d.Dpt).WithMany(p => p.LaboratoriosDirs)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LaboratoriosDirs_Departamentos");

            entity.HasOne(d => d.LabCodigoNavigation).WithMany(p => p.LaboratoriosDirs)
                .HasForeignKey(d => d.LabCodigo)
                .HasConstraintName("FK_LaboratoriosDirs_Laboratorios");
        });

        modelBuilder.Entity<LaboratoriosGrupo>(entity =>
        {
            entity.HasKey(e => new { e.GlaId, e.LabCodigo });

            entity.Property(e => e.GlaId).HasColumnName("GLA_ID");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.LabUsarContsDirs).HasColumnName("LAB_UsarContsDirs");

            entity.HasOne(d => d.Gla).WithMany(p => p.LaboratoriosGrupos)
                .HasForeignKey(d => d.GlaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LaboratoriosGrupos_GruposLaboratorios");

            entity.HasOne(d => d.LabCodigoNavigation).WithMany(p => p.LaboratoriosGrupos)
                .HasForeignKey(d => d.LabCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LaboratoriosGrupos_Laboratorios");
        });

        modelBuilder.Entity<LaboratoriosObj>(entity =>
        {
            entity.HasKey(e => new { e.LabCodigo, e.ObvEjercicio, e.ObvMes, e.ObvGenericos });

            entity.ToTable("LaboratoriosOBJ");

            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.ObvEjercicio).HasColumnName("OBV_Ejercicio");
            entity.Property(e => e.ObvMes).HasColumnName("OBV_Mes");
            entity.Property(e => e.ObvGenericos)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OBV_Genericos");
            entity.Property(e => e.ObvCerrado).HasColumnName("OBV_Cerrado");
            entity.Property(e => e.ObvImporteRecep)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("OBV_ImporteRecep");
            entity.Property(e => e.ObvImporteRepo)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("OBV_ImporteRepo");
            entity.Property(e => e.ObvUdsRecep).HasColumnName("OBV_UdsRecep");
            entity.Property(e => e.ObvUdsRepo).HasColumnName("OBV_UdsRepo");

            entity.HasOne(d => d.LabCodigoNavigation).WithMany(p => p.LaboratoriosObjs)
                .HasForeignKey(d => d.LabCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LaboratoriosOBJ_Laboratorios");
        });

        modelBuilder.Entity<LineasNegocio>(entity =>
        {
            entity.HasKey(e => e.LneId);

            entity.ToTable("LineasNegocio");

            entity.Property(e => e.LneId).HasColumnName("LNE_ID");
            entity.Property(e => e.LneNombre)
                .HasMaxLength(35)
                .HasColumnName("LNE_Nombre");
            entity.Property(e => e.LneOtros).HasColumnName("LNE_Otros");
            entity.Property(e => e.LneResidencias).HasColumnName("LNE_Residencias");
        });

        modelBuilder.Entity<ListasArticulosUnn>(entity =>
        {
            entity.HasKey(e => new { e.LstId, e.UnnId }).HasName("PK_ListasArticulosUNN_1");

            entity.ToTable("ListasArticulosUNN");

            entity.Property(e => e.LstId).HasColumnName("LST_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.LafId).HasColumnName("LAF_ID");
        });

        modelBuilder.Entity<LogErrore>(entity =>
        {
            entity.HasKey(e => e.LoeId);

            entity.Property(e => e.LoeId).HasColumnName("LOE_ID");
            entity.Property(e => e.LoeClase)
                .HasMaxLength(50)
                .HasColumnName("LOE_Clase");
            entity.Property(e => e.LoeError)
                .HasMaxLength(500)
                .HasColumnName("LOE_Error");
            entity.Property(e => e.LoeFalta)
                .HasMaxLength(50)
                .HasColumnName("LOE_FAlta");
            entity.Property(e => e.LoeModulo)
                .HasMaxLength(60)
                .HasColumnName("LOE_Modulo");
            entity.Property(e => e.LoeOpcion)
                .HasMaxLength(60)
                .HasColumnName("LOE_Opcion");
            entity.Property(e => e.LoeUalta)
                .HasMaxLength(50)
                .HasColumnName("LOE_UAlta");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
        });

        modelBuilder.Entity<LogLopd>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK_Log");

            entity.ToTable("LogLOPD");

            entity.Property(e => e.LogId).HasColumnName("LOG_ID");
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CudTicket)
                .HasMaxLength(100)
                .HasColumnName("CUD_Ticket");
            entity.Property(e => e.LogFecha)
                .HasColumnType("datetime")
                .HasColumnName("LOG_Fecha");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UnnIdticket)
                .HasMaxLength(100)
                .HasColumnName("UNN_IDTicket");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");
        });

        modelBuilder.Entity<LogVenta>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK_LOG_Ventas");

            entity.Property(e => e.LogId).HasColumnName("LOG_ID");
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.CudFecha)
                .HasColumnType("datetime")
                .HasColumnName("CUD_Fecha");
            entity.Property(e => e.CudTicket)
                .HasMaxLength(50)
                .HasColumnName("CUD_Ticket");
            entity.Property(e => e.CueBonos).HasColumnName("CUE_Bonos");
            entity.Property(e => e.CueId).HasColumnName("CUE_ID");
            entity.Property(e => e.CuePuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CUE_Puntos");
            entity.Property(e => e.FinBonos).HasColumnName("FIN_Bonos");
            entity.Property(e => e.FinPuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FIN_Puntos");
            entity.Property(e => e.LogError)
                .HasMaxLength(500)
                .HasColumnName("LOG_Error");
            entity.Property(e => e.OpeBonos).HasColumnName("OPE_Bonos");
            entity.Property(e => e.OpeBonosGastados).HasColumnName("OPE_BonosGastados");
            entity.Property(e => e.OpePuntos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("OPE_Puntos");
            entity.Property(e => e.TarId)
                .HasMaxLength(13)
                .HasColumnName("TAR_ID");
            entity.Property(e => e.TatId).HasColumnName("TAT_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
        });

        modelBuilder.Entity<MktTventasClienteLaboratorio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MKT_TVentasClienteLaboratorio");

            entity.Property(e => e.Cn)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CN");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Farmacia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("farmacia");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Movil)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("movil");
            entity.Property(e => e.Nombrecompleto)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombrecompleto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<MotivosCuentasDetalle>(entity =>
        {
            entity.HasKey(e => e.MotId).HasName("PK_Motivos");

            entity.ToTable("MotivosCuentasDetalle");

            entity.Property(e => e.MotId).HasColumnName("MOT_ID");
            entity.Property(e => e.MotDescripcion)
                .HasMaxLength(255)
                .HasColumnName("MOT_Descripcion");
            entity.Property(e => e.MotOperacion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MOT_Operacion");
        });

        modelBuilder.Entity<NivelConsulta>(entity =>
        {
            entity.HasKey(e => e.NicId);

            entity.Property(e => e.NicId).HasColumnName("NIC_ID");
            entity.Property(e => e.NicDescrip)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NIC_Descrip");
            entity.Property(e => e.NicFalta)
                .HasColumnType("datetime")
                .HasColumnName("NIC_FAlta");
            entity.Property(e => e.NicFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("NIC_FModificacion");
            entity.Property(e => e.NicPadre).HasColumnName("NIC_Padre");
            entity.Property(e => e.NicUalta).HasColumnName("NIC_UAlta");
            entity.Property(e => e.NicUmodificacion).HasColumnName("NIC_UModificacion");

            entity.HasOne(d => d.Padre).WithMany(p => p.Hijos)
                .HasForeignKey(d => d.NicPadre)
                .HasConstraintName("FK_NivelesConsultas_NivelesConsultas");
        });

        modelBuilder.Entity<Origene>(entity =>
        {
            entity.HasKey(e => e.OriId);

            entity.Property(e => e.OriId).HasColumnName("ORI_ID");
            entity.Property(e => e.OriDescripcion)
                .HasMaxLength(100)
                .HasColumnName("ORI_Descripcion");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.PaiId);

            entity.Property(e => e.PaiId).HasColumnName("PAI_ID");
            entity.Property(e => e.PaiNombre)
                .HasMaxLength(80)
                .HasColumnName("PAI_Nombre")
                .IsRequired();
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.ParId);

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.GlaId).HasColumnName("GLA_ID");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.ParArticulos).HasColumnName("PAR_Articulos");
            entity.Property(e => e.ParFalta)
                .HasColumnType("datetime")
                .HasColumnName("PAR_FAlta");
            entity.Property(e => e.ParFcambio)
                .HasColumnType("datetime")
                .HasColumnName("PAR_FCambio");
            entity.Property(e => e.ParFin)
                .HasColumnType("datetime")
                .HasColumnName("PAR_Fin");
            entity.Property(e => e.ParFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("PAR_FModificacion");
            entity.Property(e => e.ParHistorico).HasColumnName("PAR_Historico");
            entity.Property(e => e.ParInicio)
                .HasColumnType("datetime")
                .HasColumnName("PAR_Inicio");
            entity.Property(e => e.ParPlazoFact)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PAR_PlazoFact");
            entity.Property(e => e.ParPrimeraFact)
                .HasColumnType("datetime")
                .HasColumnName("PAR_PrimeraFact");
            entity.Property(e => e.ParSuspendido).HasColumnName("PAR_Suspendido");
            entity.Property(e => e.ParUalta).HasColumnName("PAR_UAlta");
            entity.Property(e => e.ParUcambio).HasColumnName("PAR_UCambio");
            entity.Property(e => e.ParUltFact)
                .HasColumnType("datetime")
                .HasColumnName("PAR_UltFact");
            entity.Property(e => e.ParUmodificacion).HasColumnName("PAR_UModificacion");
            entity.Property(e => e.TapId).HasColumnName("TAP_ID");

            entity.HasOne(d => d.Tap).WithMany(p => p.Partners)
                .HasForeignKey(d => d.TapId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Partners_TiposAcuerdoPartner");
        });

        modelBuilder.Entity<PartnersArticulo>(entity =>
        {
            entity.HasKey(e => new { e.ParId, e.ArtCodigo });

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");

            entity.HasOne(d => d.Par).WithMany(p => p.PartnersArticulos)
                .HasForeignKey(d => d.ParId)
                .HasConstraintName("FK_PartnersArticulos_Partners");
        });

        modelBuilder.Entity<PartnersArticulosObj>(entity =>
        {
            entity.HasKey(e => new { e.ParId, e.ArtCodigo, e.ObvEjercicio, e.ObvMes });

            entity.ToTable("PartnersArticulosOBJ");

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ObvEjercicio).HasColumnName("OBV_Ejercicio");
            entity.Property(e => e.ObvMes).HasColumnName("OBV_Mes");
            entity.Property(e => e.ObvImnporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("OBV_Imnporte");
            entity.Property(e => e.ObvUnidades).HasColumnName("OBV_Unidades");

            entity.HasOne(d => d.PartnersArticulo).WithMany(p => p.PartnersArticulosObjs)
                .HasForeignKey(d => new { d.ParId, d.ArtCodigo })
                .HasConstraintName("FK_PartnersArticulosOBJ_PartnersArticulos");
        });

        modelBuilder.Entity<PartnersCompromiso>(entity =>
        {
            entity.HasKey(e => new { e.ParId, e.CmpId });

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.CmpId).HasColumnName("CMP_ID");
            entity.Property(e => e.CmpTap).HasColumnName("CMP_TAP");
            entity.Property(e => e.PccAvisos).HasColumnName("PCC_Avisos");
            entity.Property(e => e.PccPeriodoAvisos)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PCC_PeriodoAvisos");
            entity.Property(e => e.PccUltAviso)
                .HasColumnType("datetime")
                .HasColumnName("PCC_UltAviso");

            entity.HasOne(d => d.Cmp).WithMany(p => p.PartnersCompromisos)
                .HasForeignKey(d => d.CmpId)
                .HasConstraintName("FK_PartnersCompromisos_PartnersDefCompromisos");

            entity.HasOne(d => d.Par).WithMany(p => p.PartnersCompromisos)
                .HasForeignKey(d => d.ParId)
                .HasConstraintName("FK_PartnersCompromisos_Partners");
        });

        modelBuilder.Entity<PartnersCompromisosAviso>(entity =>
        {
            entity.HasKey(e => e.PcaId);

            entity.Property(e => e.PcaId).HasColumnName("PCA_ID");
            entity.Property(e => e.CmpId).HasColumnName("CMP_ID");
            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.PcaAviso)
                .HasColumnType("datetime")
                .HasColumnName("PCA_Aviso");
            entity.Property(e => e.PcaRealizado)
                .HasColumnType("datetime")
                .HasColumnName("PCA_Realizado");
            entity.Property(e => e.PcaUrealizado).HasColumnName("PCA_URealizado");

            entity.HasOne(d => d.PartnersCompromiso).WithMany(p => p.PartnersCompromisosAvisos)
                .HasForeignKey(d => new { d.ParId, d.CmpId })
                .HasConstraintName("FK_PartnersCompromisosAvisos_PartnersCompromisos");
        });

        modelBuilder.Entity<PartnersCompromisosInf>(entity =>
        {
            entity.HasKey(e => new { e.ParId, e.CmpId, e.InfId });

            entity.ToTable("PartnersCompromisosInf");

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.CmpId).HasColumnName("CMP_ID");
            entity.Property(e => e.InfId).HasColumnName("INF_ID");

            entity.HasOne(d => d.PartnersCompromiso).WithMany(p => p.PartnersCompromisosInfs)
                .HasForeignKey(d => new { d.ParId, d.CmpId })
                .HasConstraintName("FK_PartnersCompromisosInf_PartnersCompromisos");
        });

        modelBuilder.Entity<PartnersCompromisosPub>(entity =>
        {
            entity.HasKey(e => new { e.ParId, e.CmpId, e.PubId });

            entity.ToTable("PartnersCompromisosPub");

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.CmpId).HasColumnName("CMP_ID");
            entity.Property(e => e.PubId).HasColumnName("PUB_ID");
            entity.Property(e => e.PubNumIns).HasColumnName("PUB_NumIns");

            //entity.HasOne(d => d.Pub).WithMany(p => p.PartnersCompromisosPubs)
            //    .HasForeignKey(d => d.PubId)
            //    .HasConstraintName("FK_PartnersCompromisosPub_Publicaciones");

            entity.HasOne(d => d.PartnersCompromiso).WithMany(p => p.PartnersCompromisosPubs)
                .HasForeignKey(d => new { d.ParId, d.CmpId })
                .HasConstraintName("FK_PartnersCompromisosPub_PartnersCompromisos");
        });

        modelBuilder.Entity<PartnersConcepto>(entity =>
        {
            entity.HasKey(e => new { e.ParId, e.CftId });

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.CftId).HasColumnName("CFT_ID");
            entity.Property(e => e.CftTap).HasColumnName("CFT_TAP");
            entity.Property(e => e.PpcImpBrutoAnual)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PPC_ImpBrutoAnual");
            entity.Property(e => e.PpcNoFacturar).HasColumnName("PPC_NoFacturar");

            entity.HasOne(d => d.Cft).WithMany(p => p.PartnersConceptos)
                .HasForeignKey(d => d.CftId)
                .HasConstraintName("FK_PartnersConceptos_FacturasTrebolConceptos");

            entity.HasOne(d => d.Par).WithMany(p => p.PartnersConceptos)
                .HasForeignKey(d => d.ParId)
                .HasConstraintName("FK_PartnersConceptos_Partners");
        });

        modelBuilder.Entity<PartnersDefCompromiso>(entity =>
        {
            entity.HasKey(e => e.CmpId);

            entity.Property(e => e.CmpId).HasColumnName("CMP_ID");
            entity.Property(e => e.CmpDescrip)
                .HasMaxLength(100)
                .HasColumnName("CMP_Descrip");
            entity.Property(e => e.CmpInformes).HasColumnName("CMP_Informes");
            entity.Property(e => e.CmpPublicidad).HasColumnName("CMP_Publicidad");
        });

        modelBuilder.Entity<PartnersDocumento>(entity =>
        {
            entity.HasKey(e => new { e.ParId, e.DocId });

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.DocId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DOC_ID");
            entity.Property(e => e.DocLink)
                .HasMaxLength(255)
                .HasColumnName("DOC_Link");
            entity.Property(e => e.DocNombre)
                .HasMaxLength(100)
                .HasColumnName("DOC_Nombre");

            entity.HasOne(d => d.Par).WithMany(p => p.PartnersDocumentos)
                .HasForeignKey(d => d.ParId)
                .HasConstraintName("FK_PartnersDocumentos_Partners");
        });

        modelBuilder.Entity<PartnersGestore>(entity =>
        {
            entity.HasKey(e => new { e.ParId, e.UsrId });

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");

            entity.HasOne(d => d.Par).WithMany(p => p.PartnersGestores)
                .HasForeignKey(d => d.ParId)
                .HasConstraintName("FK_PartnersGestores_Partners");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedId);

            entity.Property(e => e.PedId).HasColumnName("PED_ID");
            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");
        });

        modelBuilder.Entity<PedidosNf>(entity =>
        {
            entity.HasKey(e => e.PedId);

            entity.ToTable("PedidosNF");

            entity.Property(e => e.PedId).HasColumnName("PED_ID");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.PedAvisos).HasColumnName("PED_Avisos");
            entity.Property(e => e.PedDescripcion)
                .HasMaxLength(100)
                .HasColumnName("PED_Descripcion");
            entity.Property(e => e.PedDocumento)
                .HasMaxLength(16)
                .HasColumnName("PED_Documento");
            entity.Property(e => e.PedDtoCab)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PED_DtoCab");
            entity.Property(e => e.PedDtoProv)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PED_DtoProv");
            entity.Property(e => e.PedEntregaUnica).HasColumnName("PED_EntregaUnica");
            entity.Property(e => e.PedEstado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PED_Estado");
            entity.Property(e => e.PedFalta)
                .HasColumnType("datetime")
                .HasColumnName("PED_FAlta");
            entity.Property(e => e.PedFanulacion)
                .HasColumnType("datetime")
                .HasColumnName("PED_FAnulacion");
            entity.Property(e => e.PedFemision)
                .HasColumnType("datetime")
                .HasColumnName("PED_FEmision");
            entity.Property(e => e.PedFfirma)
                .HasColumnType("datetime")
                .HasColumnName("PED_FFirma");
            entity.Property(e => e.PedFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("PED_FModificacion");
            entity.Property(e => e.PedFvencim)
                .HasColumnType("datetime")
                .HasColumnName("PED_FVencim");
            entity.Property(e => e.PedImpBruto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PED_ImpBruto");
            entity.Property(e => e.PedImpCuotas)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PED_ImpCuotas");
            entity.Property(e => e.PedImpNeto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PED_ImpNeto");
            entity.Property(e => e.PedImpTotal)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PED_ImpTotal");
            entity.Property(e => e.PedModoFactura)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PED_ModoFactura");
            entity.Property(e => e.PedReFacturar).HasColumnName("PED_ReFacturar");
            entity.Property(e => e.PedUalta).HasColumnName("PED_UAlta");
            entity.Property(e => e.PedUfirma).HasColumnName("PED_UFirma");
            entity.Property(e => e.PedUmodificacion).HasColumnName("PED_UModificacion");
            entity.Property(e => e.PnfId).HasColumnName("PNF_ID");

            entity.HasOne(d => d.Dpt).WithMany(p => p.PedidosNfs)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidosNF_Departamentos");

            entity.HasOne(d => d.Pnf).WithMany(p => p.PedidosNfs)
                .HasForeignKey(d => d.PnfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidosNF_ProveedoresNoFarmaceuticos");
        });

        modelBuilder.Entity<PedidosNfconformar>(entity =>
        {
            entity.HasKey(e => new { e.PedId, e.UnnId, e.PcoId });

            entity.ToTable("PedidosNFConformar");

            entity.Property(e => e.PedId).HasColumnName("PED_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.PcoId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PCO_ID");
            entity.Property(e => e.PcoConformeTotal).HasColumnName("PCO_ConformeTotal");
            entity.Property(e => e.PcoContabilizado).HasColumnName("PCO_Contabilizado");
            entity.Property(e => e.PcoDocFactura)
                .HasMaxLength(30)
                .HasColumnName("PCO_DocFactura");
            entity.Property(e => e.PcoFecha)
                .HasColumnType("datetime")
                .HasColumnName("PCO_Fecha");
            entity.Property(e => e.PcoImpConformado)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PCO_ImpConformado");

            entity.HasOne(d => d.PedidosNfunn).WithMany(p => p.PedidosNfconformars)
                .HasForeignKey(d => new { d.PedId, d.UnnId })
                .HasConstraintName("FK_PedidosNFConformar_PedidosNFUNN");
        });

        modelBuilder.Entity<PedidosNflinea>(entity =>
        {
            entity.HasKey(e => new { e.PedId, e.PelLinea });

            entity.ToTable("PedidosNFLineas");

            entity.Property(e => e.PedId).HasColumnName("PED_ID");
            entity.Property(e => e.PelLinea)
                .ValueGeneratedOnAdd()
                .HasColumnName("PEL_Linea");
            entity.Property(e => e.ArtDescripcion)
                .HasMaxLength(50)
                .HasColumnName("ART_Descripcion");
            entity.Property(e => e.PelAplicarDtoLin)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PEL_AplicarDtoLin");
            entity.Property(e => e.PelDtoLinea)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PEL_DtoLinea");
            entity.Property(e => e.PelImpBruto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEL_ImpBruto");
            entity.Property(e => e.PelImpCuota)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEL_ImpCuota");
            entity.Property(e => e.PelImpDto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEL_ImpDto");
            entity.Property(e => e.PelImpNeto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEL_ImpNeto");
            entity.Property(e => e.PelImpToital)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEL_ImpToital");
            entity.Property(e => e.PelPorImpuesto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PEL_PorImpuesto");
            entity.Property(e => e.PelPrecioU)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEL_PrecioU");
            entity.Property(e => e.PelUnidades).HasColumnName("PEL_Unidades");
            entity.Property(e => e.TivId).HasColumnName("TIV_ID");

            entity.HasOne(d => d.Ped).WithMany(p => p.PedidosNflineas)
                .HasForeignKey(d => d.PedId)
                .HasConstraintName("FK_PedidosNFLineas_PedidosNF");
        });

        modelBuilder.Entity<PedidosNflineasUnn>(entity =>
        {
            entity.HasKey(e => e.PluId);

            entity.ToTable("PedidosNFLineasUNN");

            entity.Property(e => e.PluId).HasColumnName("PLU_ID");
            entity.Property(e => e.PedId).HasColumnName("PED_ID");
            entity.Property(e => e.PedLinea).HasColumnName("PED_Linea");
            entity.Property(e => e.PeuFacTrebol).HasColumnName("PEU_FacTrebol");
            entity.Property(e => e.PeuImpBruto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEU_ImpBruto");
            entity.Property(e => e.PeuImpCuota)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEU_ImpCuota");
            entity.Property(e => e.PeuImpDto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEU_ImpDto");
            entity.Property(e => e.PeuImpNeto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEU_ImpNeto");
            entity.Property(e => e.PeuImpTotal)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEU_ImpTotal");
            entity.Property(e => e.PeuUnidades).HasColumnName("PEU_Unidades");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");

            entity.HasOne(d => d.Unn).WithMany(p => p.PedidosNflineasUnns)
                .HasForeignKey(d => d.UnnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidosNFLineasUNN_UnidadesNegocio");

            entity.HasOne(d => d.PedidosNflinea).WithMany(p => p.PedidosNflineasUnns)
                .HasForeignKey(d => new { d.PedId, d.PedLinea })
                .HasConstraintName("FK_PedidosNFLineasUNN_PedidosNFLineas");
        });

        modelBuilder.Entity<PedidosNfunn>(entity =>
        {
            entity.HasKey(e => new { e.PedId, e.UnnId }).HasName("PK_PedidosNFUNN_1");

            entity.ToTable("PedidosNFUNN");

            entity.Property(e => e.PedId).HasColumnName("PED_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.DirIdentrega).HasColumnName("DIR_IDEntrega");
            entity.Property(e => e.DirIdfactura).HasColumnName("DIR_IDFactura");
            entity.Property(e => e.PeuConformado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PEU_Conformado");
            entity.Property(e => e.PeuNumero)
                .HasMaxLength(25)
                .HasColumnName("PEU_Numero");
            entity.Property(e => e.PeuObserv)
                .HasMaxLength(400)
                .HasColumnName("PEU_Observ");
            entity.Property(e => e.PeuRecibido).HasColumnName("PEU_Recibido");
            entity.Property(e => e.PeuUsuRecibe).HasColumnName("PEU_UsuRecibe");
            entity.Property(e => e.SocIdfactura).HasColumnName("SOC_IDFactura");
            entity.Property(e => e.UnnIdfactura).HasColumnName("UNN_IDFactura");

            entity.HasOne(d => d.Ped).WithMany(p => p.PedidosNfunns)
                .HasForeignKey(d => d.PedId)
                .HasConstraintName("FK_PedidosNFUNN_PedidosNF");
        });

        modelBuilder.Entity<PerfilAcceso>(entity =>
        {
            entity.HasKey(e => e.PeaId);

            entity.ToTable("PerfilesAcceso");

            entity.Property(e => e.PeaId)
                .HasComment("Identificador de Perfil de Acceso")
                .HasColumnName("PEA_ID");
            entity.Property(e => e.PeaFalta)
                .HasComment("Fecha de Alta")
                .HasColumnType("datetime")
                .HasColumnName("PEA_FAlta");
            entity.Property(e => e.PeaFmodificacion)
                .HasComment("Fecha Modificación")
                .HasColumnType("datetime")
                .HasColumnName("PEA_FModificacion");
            entity.Property(e => e.PeaNombre)
                .HasMaxLength(50)
                .HasComment("Nombre perfil acceso")
                .HasColumnName("PEA_Nombre");
            entity.Property(e => e.PeaUalta)
                .HasComment("Id. Usuario Alta")
                .HasColumnName("PEA_UAlta");
            entity.Property(e => e.PeaUmodificacion)
                .HasComment("Identificador del último Usuario que modificó")
                .HasColumnName("PEA_UModificacion");

            entity.HasMany(d => d.Procesos).WithMany(p => p.Perfiles)
                .UsingEntity<Dictionary<string, object>>(
                    "PerfilesAccesoProceso",
                    r => r.HasOne<Proceso>().WithMany()
                        .HasForeignKey("ProId")
                        .HasConstraintName("FK_PerfilesAccesoProcesos_Procesos"),
                    l => l.HasOne<PerfilAcceso>().WithMany()
                        .HasForeignKey("PeaId")
                        .HasConstraintName("FK_PerfilesAccesoProcesos_PerfilesAcceso"),
                    j =>
                    {
                        j.HasKey("PeaId", "ProId");
                        j.ToTable("PerfilesAccesoProcesos");
                        j.IndexerProperty<int>("PeaId")
                            .HasComment("Id. de Perfil de Acceso")
                            .HasColumnName("PEA_ID");
                        j.IndexerProperty<string>("ProId")
                            .HasMaxLength(8)
                            .HasComment("Id. de Proceso")
                            .HasColumnName("PRO_ID");
                    });
        });

        modelBuilder.Entity<Plataforma>(entity =>
        {
            entity.HasKey(e => e.PlaId);

            entity.Property(e => e.PlaId).HasColumnName("PLA_ID");
            entity.Property(e => e.PlaActiva).HasColumnName("PLA_Activa");
            entity.Property(e => e.PlaAplicaCargoLog).HasColumnName("PLA_AplicaCargoLog");
            entity.Property(e => e.PlaAsegurarMaf).HasColumnName("PLA_AsegurarMAF");
            entity.Property(e => e.PlaCargoLogImporte)
                .HasColumnType("decimal(9, 3)")
                .HasColumnName("PLA_CargoLogImporte");
            entity.Property(e => e.PlaCargoLogPorcent)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PLA_CargoLogPorcent");
            entity.Property(e => e.PlaCargoLogTiv).HasColumnName("PLA_CargoLogTIV");
            entity.Property(e => e.PlaEditCondFarma).HasColumnName("PLA_EditCondFarma");
            entity.Property(e => e.PlaFactTrebol).HasColumnName("PLA_FactTrebol");
            entity.Property(e => e.PlaFalta)
                .HasColumnType("datetime")
                .HasColumnName("PLA_FAlta");
            entity.Property(e => e.PlaFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("PLA_FModificacion");
            entity.Property(e => e.PlaIdCartera).HasColumnName("PLA_IdCartera");
            entity.Property(e => e.PlaIdantigua)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PLA_IDAntigua");
            entity.Property(e => e.PlaLiquidacion).HasColumnName("PLA_Liquidacion");
            entity.Property(e => e.PlaModeloFt).HasColumnName("PLA_ModeloFT");
            entity.Property(e => e.PlaModeloPva)
                .HasDefaultValue((short)1)
                .HasColumnName("PLA_ModeloPVA");
            entity.Property(e => e.PlaNombre)
                .HasMaxLength(100)
                .HasColumnName("PLA_Nombre");
            entity.Property(e => e.PlaPdtesPlat).HasColumnName("PLA_PdtesPlat");
            entity.Property(e => e.PlaPrevConsumo).HasColumnName("PLA_PrevConsumo");
            entity.Property(e => e.PlaReposicion).HasColumnName("PLA_Reposicion");
            entity.Property(e => e.PlaSinPlat).HasColumnName("PLA_SinPlat");
            entity.Property(e => e.PlaSufijo)
                .HasMaxLength(10)
                .HasColumnName("PLA_Sufijo");
            entity.Property(e => e.PlaUalta).HasColumnName("PLA_UAlta");
            entity.Property(e => e.PlaUmodificacion).HasColumnName("PLA_UModificacion");
            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");

            entity.HasOne(d => d.PvfCodigoNavigation).WithMany(p => p.Plataformas)
                .HasForeignKey(d => d.PvfCodigo)
                .HasConstraintName("FK_Plataformas_Proveedores");
        });

        modelBuilder.Entity<PlataformasArticulo>(entity =>
        {
            entity.HasKey(e => e.ParId);

            entity.HasIndex(e => new { e.PlaId, e.ArtCodigo }, "IX_PlataformasArticulos");

            entity.Property(e => e.ParId).HasColumnName("PAR_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ParClimporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PAR_CLImporte");
            entity.Property(e => e.ParClporcent)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PAR_CLPorcent");
            entity.Property(e => e.ParDesactivada).HasColumnName("PAR_Desactivada");
            entity.Property(e => e.ParDtop)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("PAR_DTOP");
            entity.Property(e => e.ParDtopajustado).HasColumnName("PAR_DTOPAjustado");
            entity.Property(e => e.ParDtot)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("PAR_DTOT");
            entity.Property(e => e.ParFalta)
                .HasColumnType("datetime")
                .HasColumnName("PAR_FAlta");
            entity.Property(e => e.ParFfin)
                .HasColumnType("datetime")
                .HasColumnName("PAR_FFin");
            entity.Property(e => e.ParFinicio)
                .HasColumnType("datetime")
                .HasColumnName("PAR_FInicio");
            entity.Property(e => e.ParFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("PAR_FModificacion");
            entity.Property(e => e.ParHabitual).HasColumnName("PAR_Habitual");
            entity.Property(e => e.ParMargenFarma)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PAR_MargenFarma");
            entity.Property(e => e.ParMargenTrebol)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PAR_MargenTrebol");
            entity.Property(e => e.ParMpva)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PAR_MPVA");
            entity.Property(e => e.ParPvap)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PAR_PVAP");
            entity.Property(e => e.ParPvlp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PAR_PVLP");
            entity.Property(e => e.ParPvlt)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PAR_PVLT");
            entity.Property(e => e.ParPvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PAR_PVP");
            entity.Property(e => e.ParUalta).HasColumnName("PAR_UAlta");
            entity.Property(e => e.ParUmodificacion).HasColumnName("PAR_UModificacion");
            entity.Property(e => e.PlaId).HasColumnName("PLA_ID");

            entity.HasOne(d => d.Pla).WithMany(p => p.PlataformasArticulos)
                .HasForeignKey(d => d.PlaId)
                .HasConstraintName("FK_PlataformasArticulos_Plataformas");
        });

        modelBuilder.Entity<PlataformasArticulosObserv>(entity =>
        {
            entity.HasKey(e => e.ParId).HasName("PK_PlataformasArticulosObserv_1");

            entity.ToTable("PlataformasArticulosObserv");

            entity.Property(e => e.ParId)
                .ValueGeneratedNever()
                .HasColumnName("PAR_ID");
            entity.Property(e => e.ParObservaciones)
                .HasMaxLength(1500)
                .HasColumnName("PAR_Observaciones");

            entity.HasOne(d => d.Par).WithOne(p => p.PlataformasArticulosObserv)
                .HasForeignKey<PlataformasArticulosObserv>(d => d.ParId)
                .HasConstraintName("FK_PlataformasArticulosObserv_PlataformasArticulos");
        });

        modelBuilder.Entity<Poblacion>(entity =>
        {
            entity.HasKey(e => e.PobId);

            entity.Property(e => e.PobId).HasColumnName("POB_ID");
            entity.Property(e => e.PaiId).HasColumnName("PAI_ID");
            entity.Property(e => e.PobNombre)
                .HasMaxLength(255)
                .HasColumnName("POB_Nombre");
            entity.Property(e => e.PrvId).HasColumnName("PRV_ID");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Poblaciones)
                .HasForeignKey(d => d.PrvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Poblaciones_Provincias");
        });

        modelBuilder.Entity<Proceso>(entity =>
        {
            entity.HasKey(e => e.ProId);

            entity.Property(e => e.ProId)
                .HasMaxLength(8)
                .HasComment("Identificador")
                .HasColumnName("PRO_ID");
            entity.Property(e => e.ProAccion)
                .HasMaxLength(150)
                .HasColumnName("PRO_Accion");
            entity.Property(e => e.ProArea)
                .HasMaxLength(50)
                .HasColumnName("PRO_Area");
            entity.Property(e => e.ProController)
                .HasMaxLength(150)
                .HasColumnName("PRO_Controller");
            entity.Property(e => e.ProDescripcion)
                .HasMaxLength(255)
                .HasColumnName("PRO_Descripcion");
            entity.Property(e => e.ProDialog).HasColumnName("PRO_Dialog");
            entity.Property(e => e.ProEsModulo).HasColumnName("PRO_EsModulo");
            entity.Property(e => e.ProFarmacia).HasColumnName("PRO_Farmacia");
            entity.Property(e => e.ProImagen)
                .HasMaxLength(255)
                .HasColumnName("PRO_Imagen");
            entity.Property(e => e.ProNivel).HasColumnName("PRO_Nivel");
            entity.Property(e => e.ProNombre)
                .HasMaxLength(60)
                .HasComment("Nombre")
                .HasColumnName("PRO_Nombre");
            entity.Property(e => e.ProIconClass)
                .HasMaxLength(50)
                .HasColumnName("PRO_IconClass");
            entity.Property(e => e.ProVisibleWeb).HasColumnName("PRO_VisibleWeb");
        });

        modelBuilder.Entity<Promocione>(entity =>
        {
            entity.HasKey(e => e.PrmId);

            entity.Property(e => e.PrmId).HasColumnName("PRM_ID");
            entity.Property(e => e.PfrId).HasColumnName("PFR_ID");
            entity.Property(e => e.PmrFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("PMR_FModificacion");
            entity.Property(e => e.PrmActiva).HasColumnName("PRM_Activa");
            entity.Property(e => e.PrmDescripcion)
                .HasMaxLength(100)
                .HasColumnName("PRM_Descripcion");
            entity.Property(e => e.PrmFalta)
                .HasColumnType("datetime")
                .HasColumnName("PRM_FAlta");
            entity.Property(e => e.PrmFcierre)
                .HasColumnType("datetime")
                .HasColumnName("PRM_FCierre");
            entity.Property(e => e.PrmTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRM_Tipo");
            entity.Property(e => e.PrmUalta).HasColumnName("PRM_UAlta");
            entity.Property(e => e.PrmUcierre).HasColumnName("PRM_UCierre");
            entity.Property(e => e.PrmUmodificacion).HasColumnName("PRM_UModificacion");

            entity.HasOne(d => d.Pfr).WithMany(p => p.Promociones)
                .HasForeignKey(d => d.PfrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Promociones_PromocionesFranjas");

            entity.HasMany(d => d.Unns).WithMany(p => p.Prms)
                .UsingEntity<Dictionary<string, object>>(
                    "PromocionesUnn",
                    r => r.HasOne<UnidadNegocio>().WithMany()
                        .HasForeignKey("UnnId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PromocionesUNN_UnidadesNegocio"),
                    l => l.HasOne<Promocione>().WithMany()
                        .HasForeignKey("PrmId")
                        .HasConstraintName("FK_PromocionesUNN_Promociones"),
                    j =>
                    {
                        j.HasKey("PrmId", "UnnId");
                        j.ToTable("PromocionesUNN");
                        j.IndexerProperty<int>("PrmId").HasColumnName("PRM_ID");
                        j.IndexerProperty<int>("UnnId").HasColumnName("UNN_ID");
                    });
        });

        modelBuilder.Entity<PromocionesCierre>(entity =>
        {
            entity.HasKey(e => e.PrcId);

            entity.HasIndex(e => new { e.PrmId, e.PrcEjercicio, e.PrcMes }, "IX_PromocionesCierres").IsUnique();

            entity.Property(e => e.PrcId).HasColumnName("PRC_ID");
            entity.Property(e => e.PfcId).HasColumnName("PFC_ID");
            entity.Property(e => e.PrcEjercicio).HasColumnName("PRC_Ejercicio");
            entity.Property(e => e.PrcMes).HasColumnName("PRC_Mes");
            entity.Property(e => e.PrmId).HasColumnName("PRM_ID");

            entity.HasOne(d => d.Pfc).WithMany(p => p.PromocionesCierres)
                .HasForeignKey(d => d.PfcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PromocionesCierres_PromocionesFranjasCierre");

            entity.HasOne(d => d.Prm).WithMany(p => p.PromocionesCierres)
                .HasForeignKey(d => d.PrmId)
                .HasConstraintName("FK_PromocionesCierres_Promociones");

            entity.HasMany(d => d.Unns).WithMany(p => p.Prcs)
                .UsingEntity<Dictionary<string, object>>(
                    "PromocionesCierresUnn",
                    r => r.HasOne<UnidadNegocio>().WithMany()
                        .HasForeignKey("UnnId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PromocionesCierresUNN_UnidadesNegocio"),
                    l => l.HasOne<PromocionesCierre>().WithMany()
                        .HasForeignKey("PrcId")
                        .HasConstraintName("FK_PromocionesCierresUNN_PromocionesCierres"),
                    j =>
                    {
                        j.HasKey("PrcId", "UnnId");
                        j.ToTable("PromocionesCierresUNN");
                        j.IndexerProperty<int>("PrcId").HasColumnName("PRC_ID");
                        j.IndexerProperty<int>("UnnId").HasColumnName("UNN_ID");
                    });
        });

        modelBuilder.Entity<PromocionesElemento>(entity =>
        {
            entity.HasKey(e => e.PmeId).HasName("PK_PromocionesOfertasF");

            entity.HasIndex(e => new { e.PrmId, e.EleId }, "IX_PromocionesOfertasF").IsUnique();

            entity.Property(e => e.PmeId).HasColumnName("PME_ID");
            entity.Property(e => e.EleId)
                .HasMaxLength(10)
                .HasColumnName("ELE_ID");
            entity.Property(e => e.PmeBonifica).HasColumnName("PME_Bonifica");
            entity.Property(e => e.PmeDescripcion)
                .HasMaxLength(32)
                .HasColumnName("PME_Descripcion");
            entity.Property(e => e.PmeDtoAplic)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PME_DtoAplic");
            entity.Property(e => e.PmePermiteDtoV).HasColumnName("PME_PermiteDtoV");
            entity.Property(e => e.PmeTipoElemento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PME_TipoElemento");
            entity.Property(e => e.PmeTipoVenta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PME_TipoVenta");
            entity.Property(e => e.PrmId).HasColumnName("PRM_ID");

            entity.HasOne(d => d.Prm).WithMany(p => p.PromocionesElementos)
                .HasForeignKey(d => d.PrmId)
                .HasConstraintName("FK_PromocionesElementos_Promociones1");
        });

        modelBuilder.Entity<PromocionesElementosCierre>(entity =>
        {
            entity.HasKey(e => e.PecId);

            entity.ToTable("PromocionesElementosCierre");

            entity.HasIndex(e => new { e.PrcId, e.EleId }, "IX_PromocionesElementosCierre");

            entity.Property(e => e.PecId).HasColumnName("PEC_ID");
            entity.Property(e => e.EleId)
                .HasMaxLength(10)
                .HasColumnName("ELE_ID");
            entity.Property(e => e.PecBonifica).HasColumnName("PEC_Bonifica");
            entity.Property(e => e.PecDescripcion)
                .HasMaxLength(32)
                .HasColumnName("PEC_Descripcion");
            entity.Property(e => e.PecDtoAplic)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEC_DtoAplic");
            entity.Property(e => e.PecPermiteDtoV).HasColumnName("PEC_PermiteDtoV");
            entity.Property(e => e.PecTipoElemento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PEC_TipoElemento");
            entity.Property(e => e.PecTipoVenta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PEC_TipoVenta");
            entity.Property(e => e.PrcId).HasColumnName("PRC_ID");

            entity.HasOne(d => d.Prc).WithMany(p => p.PromocionesElementosCierres)
                .HasForeignKey(d => d.PrcId)
                .HasConstraintName("FK_PromocionesElementosCierre_PromocionesCierres");
        });

        modelBuilder.Entity<PromocionesElementosObserv>(entity =>
        {
            entity.HasKey(e => new { e.PmeId, e.PoeLinea });

            entity.ToTable("PromocionesElementosObserv");

            entity.Property(e => e.PmeId).HasColumnName("PME_ID");
            entity.Property(e => e.PoeLinea).HasColumnName("POE_Linea");
            entity.Property(e => e.PoeObservacion)
                .HasMaxLength(255)
                .HasColumnName("POE_Observacion");

            entity.HasOne(d => d.Pme).WithMany(p => p.PromocionesElementosObservs)
                .HasForeignKey(d => d.PmeId)
                .HasConstraintName("FK_PromocionesElementosObserv_PromocionesElementos");
        });

        modelBuilder.Entity<PromocionesElementosObservCierre>(entity =>
        {
            entity.HasKey(e => new { e.PecId, e.PocId });

            entity.ToTable("PromocionesElementosObservCierre");

            entity.Property(e => e.PecId).HasColumnName("PEC_ID");
            entity.Property(e => e.PocId).HasColumnName("POC_ID");
            entity.Property(e => e.PocObservacion)
                .HasMaxLength(255)
                .HasColumnName("POC_Observacion");

            entity.HasOne(d => d.Pec).WithMany(p => p.PromocionesElementosObservCierres)
                .HasForeignKey(d => d.PecId)
                .HasConstraintName("FK_PromocionesElementosObservCierre_PromocionesElementosCierre");
        });

        modelBuilder.Entity<PromocionesElementosUnnartCierre>(entity =>
        {
            entity.HasKey(e => new { e.PcaId, e.ArtCodigo });

            entity.ToTable("PromocionesElementosUNNArtCierre");

            entity.Property(e => e.PcaId).HasColumnName("PCA_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.PcaImporteObj)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PCA_ImporteObj");
            entity.Property(e => e.PcaUdsObj).HasColumnName("PCA_UdsObj");

            entity.HasOne(d => d.Pca).WithMany(p => p.PromocionesElementosUnnartCierres)
                .HasForeignKey(d => d.PcaId)
                .HasConstraintName("FK_PromocionesElementosUNNArtCierre_PromocionesElementosUNNCierre");
        });

        modelBuilder.Entity<PromocionesElementosUnncierre>(entity =>
        {
            entity.HasKey(e => e.PcaId);

            entity.ToTable("PromocionesElementosUNNCierre");

            entity.HasIndex(e => new { e.PecId, e.UnnId }, "IX_PromocionesElementosUNNCierre").IsUnique();

            entity.Property(e => e.PcaId).HasColumnName("PCA_ID");
            entity.Property(e => e.PecId).HasColumnName("PEC_ID");
            entity.Property(e => e.PecImporteObj)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("PEC_ImporteObj");
            entity.Property(e => e.PecUdsObj).HasColumnName("PEC_UdsObj");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
        });

        modelBuilder.Entity<PromocionesFranja>(entity =>
        {
            entity.HasKey(e => e.PfrId);

            entity.Property(e => e.PfrId).HasColumnName("PFR_ID");
            entity.Property(e => e.PfrDescripcion)
                .HasMaxLength(32)
                .HasColumnName("PFR_Descripcion");
        });

        modelBuilder.Entity<PromocionesFranjasCierre>(entity =>
        {
            entity.HasKey(e => e.PfcId);

            entity.ToTable("PromocionesFranjasCierre");

            entity.Property(e => e.PfcId).HasColumnName("PFC_ID");
            entity.Property(e => e.PfcDescripcion)
                .HasMaxLength(32)
                .HasColumnName("PFC_Descripcion");
        });

        modelBuilder.Entity<PromocionesFranjasLinea>(entity =>
        {
            entity.HasKey(e => new { e.PfrId, e.PlfIdlinea });

            entity.Property(e => e.PfrId).HasColumnName("PFR_ID");
            entity.Property(e => e.PlfIdlinea).HasColumnName("PLF_IDLinea");
            entity.Property(e => e.PlfDiaDesde).HasColumnName("PLF_DiaDesde");
            entity.Property(e => e.PlfDiaHasta).HasColumnName("PLF_DiaHasta");
            entity.Property(e => e.PlfMesDesde).HasColumnName("PLF_MesDesde");
            entity.Property(e => e.PlfMesHasta).HasColumnName("PLF_MesHasta");
            entity.Property(e => e.PlfMesesCompletos).HasColumnName("PLF_MesesCompletos");

            entity.HasOne(d => d.Pfr).WithMany(p => p.PromocionesFranjasLineas)
                .HasForeignKey(d => d.PfrId)
                .HasConstraintName("FK_PromocionesFranjasLineas_PromocionesFranjas");
        });

        modelBuilder.Entity<PromocionesFranjasLineasCierre>(entity =>
        {
            entity.HasKey(e => new { e.PfcId, e.PlcIdlinea });

            entity.ToTable("PromocionesFranjasLineasCierre");

            entity.Property(e => e.PfcId).HasColumnName("PFC_ID");
            entity.Property(e => e.PlcIdlinea).HasColumnName("PLC_IDLinea");
            entity.Property(e => e.PlcDiaDesde).HasColumnName("PLC_DiaDesde");
            entity.Property(e => e.PlcDiaHasta).HasColumnName("PLC_DiaHasta");
            entity.Property(e => e.PlcMesDesde).HasColumnName("PLC_MesDesde");
            entity.Property(e => e.PlcMesHasta).HasColumnName("PLC_MesHasta");

            entity.HasOne(d => d.Pfc).WithMany(p => p.PromocionesFranjasLineasCierres)
                .HasForeignKey(d => d.PfcId)
                .HasConstraintName("FK_PromocionesFranjasLineasCierre_PromocionesFranjasCierre");
        });

        modelBuilder.Entity<PromocionesFranjasUnncierre>(entity =>
        {
            entity.HasKey(e => new { e.PfcId, e.UnnId });

            entity.ToTable("PromocionesFranjasUNNCierre");

            entity.Property(e => e.PfcId).HasColumnName("PFC_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");

            entity.HasOne(d => d.Pfc).WithMany(p => p.PromocionesFranjasUnncierres)
                .HasForeignKey(d => d.PfcId)
                .HasConstraintName("FK_PromocionesFranjasUNNCierre_PromocionesFranjasCierre");
        });

        modelBuilder.Entity<PromocionesObj>(entity =>
        {
            entity.HasKey(e => e.PmoId);

            entity.ToTable("PromocionesOBJ");

            entity.HasIndex(e => new { e.PmeId, e.UnnId, e.PobEjercicio, e.PobMes }, "IX_PromocionesOBJ").IsUnique();

            entity.Property(e => e.PmoId).HasColumnName("PMO_ID");
            entity.Property(e => e.PmeId).HasColumnName("PME_ID");
            entity.Property(e => e.PobEjercicio).HasColumnName("POB_Ejercicio");
            entity.Property(e => e.PobImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("POB_Importe");
            entity.Property(e => e.PobMes).HasColumnName("POB_Mes");
            entity.Property(e => e.PobPvp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("POB_PVP");
            entity.Property(e => e.PobUnidades).HasColumnName("POB_Unidades");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");

            entity.HasOne(d => d.Pme).WithMany(p => p.PromocionesObjs)
                .HasForeignKey(d => d.PmeId)
                .HasConstraintName("FK_PromocionesOBJ_PromocionesElementos");
        });

        modelBuilder.Entity<PromocionesObjarticulo>(entity =>
        {
            entity.HasKey(e => new { e.PmoId, e.ArtCodigo });

            entity.ToTable("PromocionesOBJArticulos");

            entity.Property(e => e.PmoId).HasColumnName("PMO_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.PoaImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("POA_Importe");
            entity.Property(e => e.PoaUnidades).HasColumnName("POA_Unidades");

            entity.HasOne(d => d.Pmo).WithMany(p => p.PromocionesObjarticulos)
                .HasForeignKey(d => d.PmoId)
                .HasConstraintName("FK_PromocionesOBJArticulos_PromocionesOBJ");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.PvfCodigo);

            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");
            entity.Property(e => e.CarId).HasColumnName("CAR_ID");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.PvfEnFactTrebol).HasColumnName("PVF_EnFactTrebol");
            entity.Property(e => e.PvfEsAlmacenTrebol).HasColumnName("PVF_EsAlmacenTrebol");
            entity.Property(e => e.PvfEsTraspaso).HasColumnName("PVF_EsTraspaso");
            entity.Property(e => e.PvfFalta)
                .HasColumnType("datetime")
                .HasColumnName("PVF_FAlta");
            entity.Property(e => e.PvfFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("PVF_FModificacion");
            entity.Property(e => e.PvfIdFiscal)
                .HasMaxLength(15)
                .HasColumnName("PVF_IdFiscal");
            entity.Property(e => e.PvfNombre)
                .HasMaxLength(35)
                .HasColumnName("PVF_Nombre");
            entity.Property(e => e.PvfRevCada).HasColumnName("PVF_RevCada");
            entity.Property(e => e.PvfRevPeriodo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_RevPeriodo");
            entity.Property(e => e.PvfRevUltFecha)
                .HasColumnType("datetime")
                .HasColumnName("PVF_RevUltFecha");
            entity.Property(e => e.PvfRevUsr).HasColumnName("PVF_RevUsr");
            entity.Property(e => e.PvfRevisarCc).HasColumnName("PVF_RevisarCC");
            entity.Property(e => e.PvfUalta).HasColumnName("PVF_UALta");
            entity.Property(e => e.PvfUmodificacion).HasColumnName("PVF_UModificacion");
            entity.Property(e => e.PvfWeb)
                .HasMaxLength(255)
                .HasColumnName("PVF_Web");

            entity.HasOne(d => d.LabCodigoNavigation).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.LabCodigo)
                .HasConstraintName("FK_Proveedores_Laboratorios");
        });

        modelBuilder.Entity<ProveedoresCalculosPvp>(entity =>
        {
            entity.HasKey(e => e.CalLinId);

            entity.ToTable("ProveedoresCalculosPVP");

            entity.HasIndex(e => new { e.PvfCodigo, e.TivId, e.FamId, e.GrpFacturacion }, "IX_ProveedoresCalculosPVP").IsUnique();

            entity.Property(e => e.CalLinId).HasColumnName("CAL_LinID");
            entity.Property(e => e.CalFactor)
                .HasColumnType("decimal(9, 3)")
                .HasColumnName("CAL_Factor");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.GrpFacturacion)
                .HasMaxLength(10)
                .HasColumnName("GRP_Facturacion");
            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");
            entity.Property(e => e.TivId).HasColumnName("TIV_ID");

            entity.HasOne(d => d.PvfCodigoNavigation).WithMany(p => p.ProveedoresCalculosPvps)
                .HasForeignKey(d => d.PvfCodigo)
                .HasConstraintName("FK_ProveedoresCalculosPVP_Proveedores");

            entity.HasOne(d => d.Tiv).WithMany(p => p.ProveedoresCalculosPvps)
                .HasForeignKey(d => d.TivId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedoresCalculosPVP_TiposIVA");
        });

        modelBuilder.Entity<ProveedoresCondCompra>(entity =>
        {
            entity.HasKey(e => e.CcpId);

            entity.ToTable("ProveedoresCondCompra");

            entity.Property(e => e.CcpId).HasColumnName("CCP_ID");
            entity.Property(e => e.CcpDesde)
                .HasColumnType("datetime")
                .HasColumnName("CCP_Desde");
            entity.Property(e => e.CcpDto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CCP_Dto");
            entity.Property(e => e.CcpHasta)
                .HasColumnType("datetime")
                .HasColumnName("CCP_Hasta");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");

            entity.HasOne(d => d.PvfCodigoNavigation).WithMany(p => p.ProveedoresCondCompras)
                .HasForeignKey(d => d.PvfCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProveedoresCondCompra_Proveedores");
        });

        modelBuilder.Entity<ProveedoresContacto>(entity =>
        {
            entity.HasKey(e => new { e.PvfCodigo, e.ConId });

            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");
            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConDefecto).HasColumnName("CON_Defecto");
            entity.Property(e => e.ConPropio).HasColumnName("CON_Propio");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Con).WithMany(p => p.ProveedoresContactos)
                .HasForeignKey(d => d.ConId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedoresContactos_Contactos");

            entity.HasOne(d => d.Dpt).WithMany(p => p.ProveedoresContactos)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedoresContactos_Departamentos");

            entity.HasOne(d => d.PvfCodigoNavigation).WithMany(p => p.ProveedoresContactos)
                .HasForeignKey(d => d.PvfCodigo)
                .HasConstraintName("FK_ProveedoresContactos_Proveedores");
        });

        modelBuilder.Entity<ProveedoresDir>(entity =>
        {
            entity.HasKey(e => new { e.PvfCodigo, e.DirId });

            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.DirDefecto).HasColumnName("DIR_Defecto");
            entity.Property(e => e.DirFax1)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX1");
            entity.Property(e => e.DirFax2)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX2");
            entity.Property(e => e.DirProblematica).HasColumnName("DIR_Problematica");
            entity.Property(e => e.DirPropia).HasColumnName("DIR_Propia");
            entity.Property(e => e.DirTelf1)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf1");
            entity.Property(e => e.DirTelf2)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf2");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Dir).WithMany(p => p.ProveedoresDirs)
                .HasForeignKey(d => d.DirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedoresDirs_Direcciones");

            entity.HasOne(d => d.Dpt).WithMany(p => p.ProveedoresDirs)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedoresDirs_Departamentos");

            entity.HasOne(d => d.PvfCodigoNavigation).WithMany(p => p.ProveedoresDirs)
                .HasForeignKey(d => d.PvfCodigo)
                .HasConstraintName("FK_ProveedoresDirs_Proveedores");
        });

        modelBuilder.Entity<ProveedoresGrupo>(entity =>
        {
            entity.HasKey(e => new { e.GpvId, e.PvfCodigo });

            entity.Property(e => e.GpvId).HasColumnName("GPV_ID");
            entity.Property(e => e.PvfCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PVF_Codigo");
            entity.Property(e => e.PvfUsarContsDirs).HasColumnName("PVF_UsarContsDirs");

            entity.HasOne(d => d.Gpv).WithMany(p => p.ProveedoresGrupos)
                .HasForeignKey(d => d.GpvId)
                .HasConstraintName("FK_ProveedoresGrupos_GruposProveedores");

            entity.HasOne(d => d.PvfCodigoNavigation).WithMany(p => p.ProveedoresGrupos)
                .HasForeignKey(d => d.PvfCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedoresGrupos_Proveedores");
        });

        modelBuilder.Entity<ProveedoresNfcondicione>(entity =>
        {
            entity.HasKey(e => new { e.PnfId, e.PccFdesde });

            entity.ToTable("ProveedoresNFCondiciones");

            entity.Property(e => e.PnfId).HasColumnName("PNF_ID");
            entity.Property(e => e.PccFdesde)
                .HasColumnType("datetime")
                .HasColumnName("PCC_FDesde");
            entity.Property(e => e.PccDto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("PCC_Dto");
            entity.Property(e => e.PccFhasta)
                .HasColumnType("datetime")
                .HasColumnName("PCC_FHasta");

            entity.HasOne(d => d.Pnf).WithMany(p => p.ProveedoresNfcondiciones)
                .HasForeignKey(d => d.PnfId)
                .HasConstraintName("FK_ProveedoresNFCondiciones_ProveedoresNoFarmaceuticos");
        });

        modelBuilder.Entity<ProveedoresNfcontacto>(entity =>
        {
            entity.HasKey(e => new { e.PnfId, e.ConId });

            entity.ToTable("ProveedoresNFContactos");

            entity.Property(e => e.PnfId).HasColumnName("PNF_ID");
            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConDefecto).HasColumnName("CON_Defecto");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Con).WithMany(p => p.ProveedoresNfcontactos)
                .HasForeignKey(d => d.ConId)
                .HasConstraintName("FK_ProveedoresNFContactos_Contactos");

            entity.HasOne(d => d.Dpt).WithMany(p => p.ProveedoresNfcontactos)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedoresNFContactos_Departamentos");

            entity.HasOne(d => d.Pnf).WithMany(p => p.ProveedoresNfcontactos)
                .HasForeignKey(d => d.PnfId)
                .HasConstraintName("FK_ProveedoresNFContactos_ProveedoresNoFarmaceuticos");
        });

        modelBuilder.Entity<ProveedoresNfdir>(entity =>
        {
            entity.HasKey(e => new { e.PnfId, e.DirId });

            entity.ToTable("ProveedoresNFDirs");

            entity.Property(e => e.PnfId).HasColumnName("PNF_ID");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.DirDefecto).HasColumnName("DIR_Defecto");
            entity.Property(e => e.DirFax1)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX1");
            entity.Property(e => e.DirFax2)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX2");
            entity.Property(e => e.DirTelf1)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf1");
            entity.Property(e => e.DirTelf2)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf2");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Dir).WithMany(p => p.ProveedoresNfdirs)
                .HasForeignKey(d => d.DirId)
                .HasConstraintName("FK_ProveedoresNFDirs_Direcciones");

            entity.HasOne(d => d.Dpt).WithMany(p => p.ProveedoresNfdirs)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProveedoresNFDirs_Departamentos");

            entity.HasOne(d => d.Pnf).WithMany(p => p.ProveedoresNfdirs)
                .HasForeignKey(d => d.PnfId)
                .HasConstraintName("FK_ProveedoresNFDirs_ProveedoresNoFarmaceuticos");
        });

        modelBuilder.Entity<ProveedoresNoFarmaceutico>(entity =>
        {
            entity.HasKey(e => e.PnfId);

            entity.Property(e => e.PnfId).HasColumnName("PNF_ID");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.PnfActivo).HasColumnName("PNF_Activo");
            entity.Property(e => e.PnfCodCliTrebol)
                .HasMaxLength(25)
                .HasColumnName("PNF_CodCliTrebol");
            entity.Property(e => e.PnfFalta)
                .HasColumnType("datetime")
                .HasColumnName("PNF_FAlta");
            entity.Property(e => e.PnfFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("PNF_FModificacion");
            entity.Property(e => e.PnfIdFiscal)
                .HasMaxLength(15)
                .HasColumnName("PNF_IdFiscal");
            entity.Property(e => e.PnfObserv)
                .HasMaxLength(500)
                .HasColumnName("PNF_Observ");
            entity.Property(e => e.PnfRazonSocial)
                .HasMaxLength(100)
                .HasColumnName("PNF_RazonSocial");
            entity.Property(e => e.PnfUalta).HasColumnName("PNF_UAlta");
            entity.Property(e => e.PnfUmodificacion).HasColumnName("PNF_UModificacion");
            entity.Property(e => e.PnfWeb)
                .HasMaxLength(255)
                .HasColumnName("PNF_Web");

            entity.HasOne(d => d.Fpa).WithMany(p => p.ProveedoresNoFarmaceuticos)
                .HasForeignKey(d => d.FpaId)
                .HasConstraintName("FK_ProveedoresNoFarmaceuticos_FormasPago");
        });

        modelBuilder.Entity<ProveedoresTrebol>(entity =>
        {
            entity.HasKey(e => e.PvtId);

            entity.ToTable("ProveedoresTrebol");

            entity.Property(e => e.PvtId).HasColumnName("PVT_ID");
            entity.Property(e => e.PvtCuenta)
                .HasMaxLength(7)
                .HasColumnName("PVT_Cuenta");
            entity.Property(e => e.PvtFalta)
                .HasColumnType("datetime")
                .HasColumnName("PVT_FAlta");
            entity.Property(e => e.PvtFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("PVT_FModificacion");
            entity.Property(e => e.PvtIdFiscal)
                .HasMaxLength(15)
                .HasColumnName("PVT_IdFiscal");
            entity.Property(e => e.PvtRazonSocial)
                .HasMaxLength(90)
                .HasColumnName("PVT_RazonSocial");
            entity.Property(e => e.PvtUalta).HasColumnName("PVT_UALta");
            entity.Property(e => e.PvtUmodificacion).HasColumnName("PVT_UModificacion");
        });

        modelBuilder.Entity<ProveedoresTrebolLaboratorio>(entity =>
        {
            entity.HasKey(e => e.PtlId);

            entity.Property(e => e.PtlId).HasColumnName("PTL_ID");
            entity.Property(e => e.LabCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LAB_Codigo");
            entity.Property(e => e.PtlFin)
                .HasColumnType("datetime")
                .HasColumnName("PTL_Fin");
            entity.Property(e => e.PtlInicio)
                .HasColumnType("datetime")
                .HasColumnName("PTL_Inicio");
            entity.Property(e => e.PvtId).HasColumnName("PVT_ID");

            entity.HasOne(d => d.LabCodigoNavigation).WithMany(p => p.ProveedoresTrebolLaboratorios)
                .HasForeignKey(d => d.LabCodigo)
                .HasConstraintName("FK_ProveedoresTrebolLaboratorios_Laboratorios");

            entity.HasOne(d => d.Pvt).WithMany(p => p.ProveedoresTrebolLaboratorios)
                .HasForeignKey(d => d.PvtId)
                .HasConstraintName("FK_ProveedoresTrebolLaboratorios_ProveedoresTrebol");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.PrvId);

            entity.Property(e => e.PrvId).HasColumnName("PRV_ID");
            entity.Property(e => e.CauId).HasColumnName("CAU_ID");
            entity.Property(e => e.PaiId).HasColumnName("PAI_ID");
            entity.Property(e => e.PrvNombre)
                .HasMaxLength(50)
                .HasColumnName("PRV_Nombre")
                .IsRequired();

            entity.HasOne(d => d.ComunidadAutonoma).WithMany(p => p.Provincias)
                .HasForeignKey(d => d.CauId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincias_ComunidadesAut");
        });

        modelBuilder.Entity<RealesDecreto>(entity =>
        {
            entity.HasKey(e => e.RdcId);

            entity.Property(e => e.RdcId).HasColumnName("RDC_ID");
            entity.Property(e => e.RdcDescrip)
                .HasMaxLength(100)
                .HasColumnName("RDC_Descrip");
            entity.Property(e => e.RdcInhabilitado).HasColumnName("RDC_Inhabilitado");
        });

        modelBuilder.Entity<RealesDecretosUnn>(entity =>
        {
            entity.HasKey(e => new { e.RdcId, e.UnnId, e.RduEjercicio, e.RduMes });

            entity.ToTable("RealesDecretosUNN");

            entity.Property(e => e.RdcId).HasColumnName("RDC_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.RduEjercicio).HasColumnName("RDU_Ejercicio");
            entity.Property(e => e.RduMes).HasColumnName("RDU_Mes");
            entity.Property(e => e.RduImporte)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("RDU_Importe");

            entity.HasOne(d => d.Rdc).WithMany(p => p.RealesDecretosUnns)
                .HasForeignKey(d => d.RdcId)
                .HasConstraintName("FK_RealesDecretosUNN_RealesDecretos");

            entity.HasOne(d => d.Unn).WithMany(p => p.RealesDecretosUnns)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_RealesDecretosUNN_UnidadesNegocio");
        });       

        modelBuilder.Entity<RolEmpleado>(entity =>
        {
            entity.HasKey(e => e.RolId);

            entity.Property(e => e.RolId).HasColumnName("ROL_ID");
            entity.Property(e => e.RolCoordinador).HasColumnName("ROL_Coordinador");
            entity.Property(e => e.RolGerente).HasColumnName("ROL_Gerente");
            entity.Property(e => e.RolNombre)
                .HasMaxLength(50)
                .HasColumnName("ROL_Nombre");
            entity.Property(e => e.RolTitular).HasColumnName("ROL_Titular");
        });

        modelBuilder.Entity<Sociedade>(entity =>
        {
            entity.HasKey(e => e.SocId);

            entity.Property(e => e.SocId).HasColumnName("SOC_ID");
            entity.Property(e => e.DirFax2)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX2");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.SocAlias)
                .HasMaxLength(150)
                .HasColumnName("SOC_Alias");
            entity.Property(e => e.SocCalConImp).HasColumnName("SOC_CalConImp");
            entity.Property(e => e.SocFax1)
                .HasMaxLength(15)
                .HasColumnName("SOC_FAX1");
            entity.Property(e => e.SocIdFiscal)
                .HasMaxLength(15)
                .HasColumnName("SOC_IdFiscal");
            entity.Property(e => e.SocLinkLogoFac)
                .HasMaxLength(255)
                .HasColumnName("SOC_LinkLogoFac");
            entity.Property(e => e.SocRazon)
                .HasMaxLength(150)
                .HasColumnName("SOC_Razon");
            entity.Property(e => e.SocTelf1)
                .HasMaxLength(15)
                .HasColumnName("SOC_Telf1");
            entity.Property(e => e.SocTelf2)
                .HasMaxLength(15)
                .HasColumnName("SOC_Telf2");

            entity.HasOne(d => d.Dir).WithMany(p => p.Sociedades)
                .HasForeignKey(d => d.DirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sociedades_Direcciones");
        });

        modelBuilder.Entity<SociedadesCcc>(entity =>
        {
            entity.HasKey(e => new { e.SocId, e.CccId });

            entity.ToTable("SociedadesCCC");

            entity.Property(e => e.SocId).HasColumnName("SOC_ID");
            entity.Property(e => e.CccId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CCC_ID");
            entity.Property(e => e.BanCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BAN_Codigo");
            entity.Property(e => e.CccCodigo)
                .HasMaxLength(12)
                .HasColumnName("CCC_Codigo");
            entity.Property(e => e.CccDefecto).HasColumnName("CCC_Defecto");
            entity.Property(e => e.CccIban)
                .HasMaxLength(34)
                .HasColumnName("CCC_IBAN");
            entity.Property(e => e.SucCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SUC_Codigo");

            entity.HasOne(d => d.BanCodigoNavigation).WithMany(p => p.SociedadesCccs)
                .HasForeignKey(d => d.BanCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SociedadesCCC_Bancos");

            entity.HasOne(d => d.Soc).WithMany(p => p.SociedadesCccs)
                .HasForeignKey(d => d.SocId)
                .HasConstraintName("FK_SociedadesCCC_Sociedades");
        });

        modelBuilder.Entity<TStockDiarioActualizado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("t_stock_diario_actualizado");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Direccion)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_actualizacion");
            entity.Property(e => e.Idarticu)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idarticu");
            entity.Property(e => e.Idfarmacia)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("idfarmacia");
            entity.Property(e => e.Stockactual).HasColumnName("stockactual");
        });

        modelBuilder.Entity<TarjetasCambio>(entity =>
        {
            entity.HasKey(e => e.TacId);

            entity.Property(e => e.TacId).HasColumnName("TAC_ID");
            entity.Property(e => e.TacActivo).HasColumnName("TAC_Activo");
            entity.Property(e => e.TacDescripcion)
                .HasMaxLength(150)
                .HasColumnName("TAC_Descripcion");
            entity.Property(e => e.TacFalta)
                .HasColumnType("datetime")
                .HasColumnName("TAC_FAlta");
            entity.Property(e => e.TacFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("TAC_FModificacion");
            entity.Property(e => e.TacUalta).HasColumnName("TAC_UAlta");
            entity.Property(e => e.TacUmodificacion).HasColumnName("TAC_UModificacion");
        });

        modelBuilder.Entity<TarjetasCambiosCliente>(entity =>
        {
            entity.HasKey(e => new { e.TacId, e.CliId }).HasName("PK_TarjetasCambiosClientes_1");

            entity.Property(e => e.TacId).HasColumnName("TAC_ID");
            entity.Property(e => e.CliId).HasColumnName("CLI_ID");
            entity.Property(e => e.TatIdnueva).HasColumnName("TAT_IDNueva");
            entity.Property(e => e.TccEstado).HasColumnName("TCC_Estado");

            entity.HasOne(d => d.Cli).WithMany(p => p.TarjetasCambiosClientes)
                .HasForeignKey(d => d.CliId)
                .HasConstraintName("FK_TarjetasCambiosClientes_Clientes");

            entity.HasOne(d => d.Tac).WithMany(p => p.TarjetasCambiosClientes)
                .HasForeignKey(d => d.TacId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TarjetasCambiosClientes_TarjetasCambios");
        });

        modelBuilder.Entity<TarjetasTipo>(entity =>
        {
            entity.HasKey(e => e.TatId);

            entity.Property(e => e.TatId).HasColumnName("TAT_ID");
            entity.Property(e => e.TatAlternativa).HasColumnName("TAT_Alternativa");
            entity.Property(e => e.TatCaducidad).HasColumnName("TAT_Caducidad");
            entity.Property(e => e.TatDescripcion)
                .HasMaxLength(100)
                .HasColumnName("TAT_Descripcion");
            entity.Property(e => e.TatIdasociada).HasColumnName("TAT_IDAsociada");
            entity.Property(e => e.TatLigadaEdad).HasColumnName("TAT_LigadaEdad");
            entity.Property(e => e.TatLimiteMax).HasColumnName("TAT_LimiteMax");
            entity.Property(e => e.TatLimiteMin).HasColumnName("TAT_LimiteMin");
            entity.Property(e => e.TatUsoVirtual).HasColumnName("TAT_UsoVirtual");
        });

        modelBuilder.Entity<TarjetasTiposUsoVirtual>(entity =>
        {
            entity.HasKey(e => e.TatId).HasName("PK_TarjetasTipoUsoVirtual");

            entity.ToTable("TarjetasTiposUsoVirtual");

            entity.Property(e => e.TatId)
                .ValueGeneratedNever()
                .HasColumnName("TAT_ID");
            entity.Property(e => e.TatRangoFin)
                .HasMaxLength(12)
                .HasColumnName("TAT_RangoFin");
            entity.Property(e => e.TatRangoInicio)
                .HasMaxLength(12)
                .HasColumnName("TAT_RangoInicio");
            entity.Property(e => e.TatUltimaTarjeta)
                .HasMaxLength(12)
                .HasColumnName("TAT_UltimaTarjeta");

            entity.HasOne(d => d.Tat).WithOne(p => p.TarjetasTiposUsoVirtual)
                .HasForeignKey<TarjetasTiposUsoVirtual>(d => d.TatId)
                .HasConstraintName("FK_TarjetasTipoUsoVirtual_TarjetasTipos");
        });

        modelBuilder.Entity<TempCliente>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bonos).HasDefaultValue(0);
            entity.Property(e => e.CliActivo).HasDefaultValue(false);
            entity.Property(e => e.CliApellido1)
                .HasMaxLength(100)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliApellido2)
                .HasMaxLength(100)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliCompra)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliCp)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("CliCP");
            entity.Property(e => e.CliDireccion)
                .HasMaxLength(150)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliDni)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("CliDNI");
            entity.Property(e => e.CliEliminado).HasDefaultValue(false);
            entity.Property(e => e.CliEmail)
                .HasMaxLength(150)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliEstadoCivil)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliFarmacia)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliFecAlta).HasColumnType("datetime");
            entity.Property(e => e.CliFecCrea).HasColumnType("datetime");
            entity.Property(e => e.CliFecMod).HasColumnType("datetime");
            entity.Property(e => e.CliFecNacimiento)
                .HasDefaultValueSql("(((1)/(1))/(1900))")
                .HasColumnType("datetime");
            entity.Property(e => e.CliId)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliIdFarmacia)
                .HasMaxLength(4)
                .IsFixedLength()
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliInfoSobre)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliNhijos)
                .HasMaxLength(10)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("CliNHijos");
            entity.Property(e => e.CliNombre)
                .HasMaxLength(100)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliOrigen)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliPoblacion)
                .HasMaxLength(150)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliProfesion)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliProvincia)
                .HasMaxLength(100)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliSexo)
                .HasMaxLength(1)
                .IsFixedLength()
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliTelefono)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliTelfMovil)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliTxtInfoSobre5)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliUsuCrea)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.CliUsuMod)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.Puntos)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.TarCb)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("TarCB");
            entity.Property(e => e.TarCbasociada)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("TarCBAsociada");
            entity.Property(e => e.TarId)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.TarIdAsociada)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
            entity.Property(e => e.TarTipo)
                .HasMaxLength(50)
                .UseCollation("Modern_Spanish_CI_AS");
        });

        modelBuilder.Entity<TipoServiciosTrebol>(entity =>
        {
            entity.HasKey(e => e.TstId);

            entity.ToTable("TipoServiciosTrebol");

            entity.Property(e => e.TstId).HasColumnName("TST_ID");
            entity.Property(e => e.CntSerie)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNT_Serie");
            entity.Property(e => e.CntSerieAbono)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNT_SerieAbono");
            entity.Property(e => e.CntSerieProForma)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CNT_SerieProForma");
            entity.Property(e => e.TstNombre)
                .HasMaxLength(100)
                .HasColumnName("TST_Nombre");
        });

        modelBuilder.Entity<TiposAcuerdoPartner>(entity =>
        {
            entity.HasKey(e => e.TapId);

            entity.ToTable("TiposAcuerdoPartner");

            entity.HasIndex(e => e.TapClase, "IX_TiposAcuerdoPartner").IsUnique();

            entity.Property(e => e.TapId).HasColumnName("TAP_ID");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.TapArticulos).HasColumnName("TAP_Articulos");
            entity.Property(e => e.TapClase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAP_Clase");
            entity.Property(e => e.TapDescripcion)
                .HasMaxLength(100)
                .HasColumnName("TAP_Descripcion");
            entity.Property(e => e.TapFalta)
                .HasColumnType("datetime")
                .HasColumnName("TAP_FAlta");
            entity.Property(e => e.TapFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("TAP_FModificacion");
            entity.Property(e => e.TapPlazoFact)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAP_PlazoFact");
            entity.Property(e => e.TapUalta).HasColumnName("TAP_UAlta");
            entity.Property(e => e.TapUmodificacion).HasColumnName("TAP_UModificacion");
        });

        modelBuilder.Entity<TiposAcuerdoPartnerComp>(entity =>
        {
            entity.HasKey(e => new { e.TapId, e.CmpId });

            entity.ToTable("TiposAcuerdoPartnerComp");

            entity.Property(e => e.TapId).HasColumnName("TAP_ID");
            entity.Property(e => e.CmpId).HasColumnName("CMP_ID");
            entity.Property(e => e.TccAvisos).HasColumnName("TCC_Avisos");
            entity.Property(e => e.TccPeriodoAvisos)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCC_PeriodoAvisos");

            entity.HasOne(d => d.Cmp).WithMany(p => p.TiposAcuerdoPartnerComps)
                .HasForeignKey(d => d.CmpId)
                .HasConstraintName("FK_TiposAcuerdoPartnerComp_PartnersDefCompromisos");

            entity.HasOne(d => d.Tap).WithMany(p => p.TiposAcuerdoPartnerComps)
                .HasForeignKey(d => d.TapId)
                .HasConstraintName("FK_TiposAcuerdoPartnerComp_TiposAcuerdoPartner");
        });

        modelBuilder.Entity<TiposAcuerdoPartnerCompInf>(entity =>
        {
            entity.HasKey(e => new { e.TapId, e.CmpId, e.InfId });

            entity.ToTable("TiposAcuerdoPartnerCompInf");

            entity.Property(e => e.TapId).HasColumnName("TAP_ID");
            entity.Property(e => e.CmpId).HasColumnName("CMP_ID");
            entity.Property(e => e.InfId).HasColumnName("INF_ID");

            entity.HasOne(d => d.TiposAcuerdoPartnerComp).WithMany(p => p.TiposAcuerdoPartnerCompInfs)
                .HasForeignKey(d => new { d.TapId, d.CmpId })
                .HasConstraintName("FK_TiposAcuerdoPartnerCompInf_TiposAcuerdoPartnerComp");
        });

        modelBuilder.Entity<TiposAcuerdoPartnerCompPub>(entity =>
        {
            entity.HasKey(e => new { e.TapId, e.CmpId, e.PubId });

            entity.ToTable("TiposAcuerdoPartnerCompPub");

            entity.Property(e => e.TapId).HasColumnName("TAP_ID");
            entity.Property(e => e.CmpId).HasColumnName("CMP_ID");
            entity.Property(e => e.PubId).HasColumnName("PUB_ID");
            entity.Property(e => e.PubNumIns).HasColumnName("PUB_NumIns");

            //entity.HasOne(d => d.Pub).WithMany(p => p.TiposAcuerdoPartnerCompPubs)
            //    .HasForeignKey(d => d.PubId)
            //    .HasConstraintName("FK_TiposAcuerdoPartnerCompPub_Publicaciones");

            entity.HasOne(d => d.TiposAcuerdoPartnerComp).WithMany(p => p.TiposAcuerdoPartnerCompPubs)
                .HasForeignKey(d => new { d.TapId, d.CmpId })
                .HasConstraintName("FK_TiposAcuerdoPartnerCompPub_TiposAcuerdoPartnerComp");
        });

        modelBuilder.Entity<TiposAcuerdoPartnerConcepto>(entity =>
        {
            entity.HasKey(e => new { e.TapId, e.CftId });

            entity.Property(e => e.TapId).HasColumnName("TAP_ID");
            entity.Property(e => e.CftId).HasColumnName("CFT_ID");
            entity.Property(e => e.TpcImpBrutoAnual)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TPC_ImpBrutoAnual");

            entity.HasOne(d => d.Cft).WithMany(p => p.TiposAcuerdoPartnerConceptos)
                .HasForeignKey(d => d.CftId)
                .HasConstraintName("FK_TiposAcuerdoPartnerConceptos_FacturasTrebolConceptos");

            entity.HasOne(d => d.Tap).WithMany(p => p.TiposAcuerdoPartnerConceptos)
                .HasForeignKey(d => d.TapId)
                .HasConstraintName("FK_TiposAcuerdoPartnerConceptos_TiposAcuerdoPartner");
        });

        modelBuilder.Entity<TiposIva>(entity =>
        {
            entity.HasKey(e => e.TivId);

            entity.ToTable("TiposIVA");

            entity.Property(e => e.TivId).HasColumnName("TIV_ID");
            entity.Property(e => e.TivExento).HasColumnName("TIV_Exento");
            entity.Property(e => e.TivIdGrpIvafarmatic)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TIV_IdGrpIVAFarmatic");
            entity.Property(e => e.TivNombre)
                .HasMaxLength(20)
                .HasColumnName("TIV_Nombre");
            entity.Property(e => e.TivServTrebol).HasColumnName("TIV_ServTrebol");
        });

        modelBuilder.Entity<TiposIvaporcentaje>(entity =>
        {
            entity.HasKey(e => new { e.TivId, e.TivFdesde });

            entity.ToTable("TiposIVAPorcentajes");

            entity.Property(e => e.TivId).HasColumnName("TIV_ID");
            entity.Property(e => e.TivFdesde)
                .HasColumnType("datetime")
                .HasColumnName("TIV_FDesde");
            entity.Property(e => e.TivPorcentaje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("TIV_Porcentaje");
            entity.Property(e => e.TivRecargoEq)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("TIV_RecargoEq");

            entity.HasOne(d => d.Tiv).WithMany(p => p.TiposIvaporcentajes)
                .HasForeignKey(d => d.TivId)
                .HasConstraintName("FK_TiposIVAPorcentajes_TiposIVA");
        });

        modelBuilder.Entity<TipoVia>(entity =>
        {
            entity.HasKey(e => e.TviId);

            entity.ToTable("TiposVial");

            entity.Property(e => e.TviId)
                .ValueGeneratedNever()
                .HasColumnName("TVI_ID");
            entity.Property(e => e.TviDefecto).HasColumnName("TVI_Defecto");
            entity.Property(e => e.TviNombre)
                .HasMaxLength(60)
                .HasColumnName("TVI_Nombre");
        });

        modelBuilder.Entity<TmpIntermediaProveedor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmp_IntermediaProveedor");

            entity.Property(e => e.CodLaboratorio).HasMaxLength(10);
            entity.Property(e => e.CodProveedor).HasMaxLength(10);
            entity.Property(e => e.NomProveedor).HasMaxLength(50);
        });

        modelBuilder.Entity<TmpPvlv>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TMP_Pvlvs");

            entity.Property(e => e.IdArticu)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Pvlv).HasColumnName("pvlv");
        });

        modelBuilder.Entity<TmpTipocliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TMP_TIPOCLIENTE");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Idtipocliente)
                .HasMaxLength(50)
                .HasColumnName("idtipocliente");
            entity.Property(e => e.Servidor).HasMaxLength(255);
            entity.Property(e => e.Trebol).HasMaxLength(50);
        });

        modelBuilder.Entity<TssarticulosEpigrafe>(entity =>
        {
            entity.HasKey(e => e.TaeId);

            entity.ToTable("TSSArticulosEpigrafe");

            entity.Property(e => e.TaeId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAE_ID");
            entity.Property(e => e.TaeDescripcion)
                .HasMaxLength(50)
                .HasColumnName("TAE_Descripcion");
        });

        modelBuilder.Entity<Tsscliente>(entity =>
        {
            entity.HasKey(e => e.ClrId);

            entity.ToTable("TSSClientes");

            entity.HasIndex(e => e.UnnId, "IX_TSSClientes");

            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.CliId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_ID");
            entity.Property(e => e.ClrActivo).HasColumnName("CLR_Activo");
            entity.Property(e => e.ClrAcuerdo).HasColumnName("CLR_Acuerdo");
            entity.Property(e => e.ClrApellido1)
                .HasMaxLength(35)
                .HasColumnName("CLR_Apellido1");
            entity.Property(e => e.ClrApellido2)
                .HasMaxLength(35)
                .HasColumnName("CLR_Apellido2");
            entity.Property(e => e.ClrFactAresidente).HasColumnName("CLR_FactAResidente");
            entity.Property(e => e.ClrFalta)
                .HasColumnType("datetime")
                .HasColumnName("CLR_FAlta");
            entity.Property(e => e.ClrFasignacion)
                .HasColumnType("datetime")
                .HasColumnName("CLR_FAsignacion");
            entity.Property(e => e.ClrFinactivo)
                .HasColumnType("datetime")
                .HasColumnName("CLR_FInactivo");
            entity.Property(e => e.ClrFmodImportacion)
                .HasColumnType("datetime")
                .HasColumnName("CLR_FModImportacion");
            entity.Property(e => e.ClrFmodificacion)
                .HasColumnType("datetime")
                .HasColumnName("CLR_FModificacion");
            entity.Property(e => e.ClrFnacimiento)
                .HasColumnType("datetime")
                .HasColumnName("CLR_FNacimiento");
            entity.Property(e => e.ClrGenDocFac).HasColumnName("CLR_GenDocFac");
            entity.Property(e => e.ClrIdfiscal)
                .HasMaxLength(15)
                .HasColumnName("CLR_IDFiscal");
            entity.Property(e => e.ClrIdpadre).HasColumnName("CLR_IDPadre");
            entity.Property(e => e.ClrMotivoInactivo)
                .HasMaxLength(255)
                .HasColumnName("CLR_MotivoInactivo");
            entity.Property(e => e.ClrNass)
                .HasMaxLength(20)
                .HasColumnName("CLR_NASS");
            entity.Property(e => e.ClrNombre)
                .HasMaxLength(50)
                .HasColumnName("CLR_Nombre");
            entity.Property(e => e.ClrOrdenFac)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLR_OrdenFac");
            entity.Property(e => e.ClrRiesgoMax)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CLR_RiesgoMax");
            entity.Property(e => e.ClrSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLR_Sexo");
            entity.Property(e => e.ClrUalta).HasColumnName("CLR_UAlta");
            entity.Property(e => e.ClrUmodificacion).HasColumnName("CLR_UModificacion");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.TclId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");

            entity.HasOne(d => d.ClrIdpadreNavigation).WithMany(p => p.InverseClrIdpadreNavigation)
                .HasForeignKey(d => d.ClrIdpadre)
                .HasConstraintName("FK_TSSClientes_TSSClientes");

            entity.HasOne(d => d.Fpa).WithMany(p => p.Tssclientes)
                .HasForeignKey(d => d.FpaId)
                .HasConstraintName("FK_TSSClientes_FormasPago");

            entity.HasOne(d => d.Unn).WithMany(p => p.Tssclientes)
                .HasForeignKey(d => d.UnnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TSSClientes_UnidadesNegocio");

            entity.HasOne(d => d.TsstiposCliente).WithMany(p => p.Tssclientes)
                .HasForeignKey(d => new { d.UnnId, d.TclId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TSSClientes_TSSTiposCliente");
        });

        modelBuilder.Entity<TssclientesAux>(entity =>
        {
            entity.HasKey(e => e.ClrId);

            entity.ToTable("TSSClientesAux");

            entity.Property(e => e.ClrId)
                .ValueGeneratedNever()
                .HasColumnName("CLR_ID");
            entity.Property(e => e.ClxCadaMe).HasColumnName("CLX_CadaME");
            entity.Property(e => e.ClxGen)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CLX_Gen");
            entity.Property(e => e.ClxImpCadaMe)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CLX_ImpCadaME");
            entity.Property(e => e.ClxImpFme)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("CLX_ImpFME");
            entity.Property(e => e.ClxModoMe)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLX_ModoME");
            entity.Property(e => e.ClxPorMe)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CLX_PorME");
            entity.Property(e => e.ClxPropio)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CLX_Propio");

            entity.HasOne(d => d.Clr).WithOne(p => p.TssclientesAux)
                .HasForeignKey<TssclientesAux>(d => d.ClrId)
                .HasConstraintName("FK_TSSClientesAux_TSSClientes");
        });

        modelBuilder.Entity<TssclientesAuxA>(entity =>
        {
            entity.HasKey(e => e.ClaId);

            entity.ToTable("TSSClientesAuxA");

            entity.Property(e => e.ClaId).HasColumnName("CLA_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ClaDescElemento)
                .HasMaxLength(100)
                .HasColumnName("CLA_DescElemento");
            entity.Property(e => e.ClaPorcentaje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CLA_Porcentaje");
            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.FamId).HasColumnName("FAM_ID");
            entity.Property(e => e.TaeId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAE_ID");

            entity.HasOne(d => d.Clr).WithMany(p => p.TssclientesAuxAs)
                .HasForeignKey(d => d.ClrId)
                .HasConstraintName("FK_TSSClientesAuxA_TSSClientes");

            entity.HasOne(d => d.Tae).WithMany(p => p.TssclientesAuxAs)
                .HasForeignKey(d => d.TaeId)
                .HasConstraintName("FK_TSSClientesAuxA_TSSArticulosEpigrafe");
        });

        modelBuilder.Entity<TssclientesCcc>(entity =>
        {
            entity.HasKey(e => new { e.ClrId, e.CccId });

            entity.ToTable("TSSClientesCCC");

            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.CccId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CCC_ID");
            entity.Property(e => e.BanCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BAN_Codigo");
            entity.Property(e => e.CccCodigo)
                .HasMaxLength(12)
                .HasColumnName("CCC_Codigo");
            entity.Property(e => e.CccDefecto).HasColumnName("CCC_Defecto");
            entity.Property(e => e.CccIban)
                .HasMaxLength(34)
                .HasColumnName("CCC_IBAN");
            entity.Property(e => e.SucCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SUC_Codigo");

            entity.HasOne(d => d.BanCodigoNavigation).WithMany(p => p.TssclientesCccs)
                .HasForeignKey(d => d.BanCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TSSClientesCCC_Bancos");

            entity.HasOne(d => d.Clr).WithMany(p => p.TssclientesCccs)
                .HasForeignKey(d => d.ClrId)
                .HasConstraintName("FK_TSSClientesCCC_TSSClientes");
        });

        modelBuilder.Entity<TssclientesCont>(entity =>
        {
            entity.HasKey(e => new { e.ClrId, e.ConId });

            entity.ToTable("TSSClientesConts");

            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.ConId).HasColumnName("CON_ID");
            entity.Property(e => e.ConDefecto).HasColumnName("CON_Defecto");
            entity.Property(e => e.DptId).HasColumnName("DPT_ID");

            entity.HasOne(d => d.Clr).WithMany(p => p.TssclientesConts)
                .HasForeignKey(d => d.ClrId)
                .HasConstraintName("FK_TSSClientesConts_TSSClientes");

            entity.HasOne(d => d.Con).WithMany(p => p.TssclientesConts)
                .HasForeignKey(d => d.ConId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TSSClientesConts_Contactos");

            entity.HasOne(d => d.Dpt).WithMany(p => p.TssclientesConts)
                .HasForeignKey(d => d.DptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TSSClientesConts_Departamentos");
        });

        modelBuilder.Entity<TssclientesDir>(entity =>
        {
            entity.HasKey(e => new { e.ClrId, e.DirId });

            entity.ToTable("TSSClientesDirs");

            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.DirDefecto).HasColumnName("DIR_Defecto");
            entity.Property(e => e.DirEnvioFactura).HasColumnName("DIR_EnvioFactura");
            entity.Property(e => e.DirFactura).HasColumnName("DIR_Factura");
            entity.Property(e => e.DirFax1)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX1");
            entity.Property(e => e.DirFax2)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX2");
            entity.Property(e => e.DirProblematica).HasColumnName("DIR_Problematica");
            entity.Property(e => e.DirTelf1)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf1");
            entity.Property(e => e.DirTelf2)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf2");

            entity.HasOne(d => d.Clr).WithMany(p => p.TssclientesDirs)
                .HasForeignKey(d => d.ClrId)
                .HasConstraintName("FK_TSSClientesDirs_TSSClientes");

            entity.HasOne(d => d.Dir).WithMany(p => p.TssclientesDirs)
                .HasForeignKey(d => d.DirId)
                .HasConstraintName("FK_TSSClientesDirs_Direcciones");
        });

        modelBuilder.Entity<TssclientesVf>(entity =>
        {
            entity.HasKey(e => new { e.ClrId, e.VefId });

            entity.ToTable("TSSClientesVF");

            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");

            entity.HasOne(d => d.Clr).WithMany(p => p.TssclientesVfs)
                .HasForeignKey(d => d.ClrId)
                .HasConstraintName("FK_TSSClientesVF_TSSClientes");
        });

        modelBuilder.Entity<TssfacturasCliente>(entity =>
        {
            entity.HasKey(e => e.FtsId);

            entity.ToTable("TSSFacturasClientes");

            entity.HasIndex(e => new { e.UnnId, e.FacIdContador }, "IX_TSSFacturasClientes").IsUnique();

            entity.Property(e => e.FtsId).HasColumnName("FTS_ID");
            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.ClrIdFiscal)
                .HasMaxLength(15)
                .HasColumnName("CLR_IdFiscal");
            entity.Property(e => e.DirIdenvio).HasColumnName("DIR_IDEnvio");
            entity.Property(e => e.DirIdfac).HasColumnName("DIR_IDFac");
            entity.Property(e => e.FacIdContador).HasColumnName("FAC_IdContador");
            entity.Property(e => e.FacNumDoc)
                .HasMaxLength(13)
                .HasColumnName("FAC_NumDoc");
            entity.Property(e => e.FtsBases)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTS_Bases");
            entity.Property(e => e.FtsCuotas)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTS_Cuotas");
            entity.Property(e => e.FtsEditada).HasColumnName("FTS_Editada");
            entity.Property(e => e.FtsExistio).HasColumnName("FTS_Existio");
            entity.Property(e => e.FtsFacTrebol).HasColumnName("FTS_FacTrebol");
            entity.Property(e => e.FtsFecha)
                .HasColumnType("datetime")
                .HasColumnName("FTS_Fecha");
            entity.Property(e => e.FtsFvencim)
                .HasColumnType("datetime")
                .HasColumnName("FTS_FVencim");
            entity.Property(e => e.FtsObservaciones)
                .HasMaxLength(255)
                .HasColumnName("FTS_Observaciones");
            entity.Property(e => e.FtsTextoFarmatic)
                .HasMaxLength(600)
                .HasColumnName("FTS_TextoFarmatic");
            entity.Property(e => e.FtsTotal)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTS_Total");
            entity.Property(e => e.FtsUnificada).HasColumnName("FTS_Unificada");
            entity.Property(e => e.SocId).HasColumnName("SOC_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");

            entity.HasOne(d => d.Clr).WithMany(p => p.TssfacturasClientes)
                .HasForeignKey(d => d.ClrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TSSFacturasClientes_TSSClientes");

            entity.HasOne(d => d.DirIdenvioNavigation).WithMany(p => p.TssfacturasClienteDirIdenvioNavigations)
                .HasForeignKey(d => d.DirIdenvio)
                .HasConstraintName("FK_TSSFacturasClientes_Direcciones1");

            entity.HasOne(d => d.DirIdfacNavigation).WithMany(p => p.TssfacturasClienteDirIdfacNavigations)
                .HasForeignKey(d => d.DirIdfac)
                .HasConstraintName("FK_TSSFacturasClientes_Direcciones");
        });

        modelBuilder.Entity<TssfacturasClientesBasis>(entity =>
        {
            entity.HasKey(e => new { e.FtsId, e.FtbPorImpuesto });

            entity.ToTable("TSSFacturasClientesBases");

            entity.Property(e => e.FtsId).HasColumnName("FTS_ID");
            entity.Property(e => e.FtbPorImpuesto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("FTB_PorImpuesto");
            entity.Property(e => e.FtbBaseImp)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTB_BaseImp");
            entity.Property(e => e.FtbCuota)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTB_Cuota");
            entity.Property(e => e.FtbTotal)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FTB_Total");

            entity.HasOne(d => d.Fts).WithMany(p => p.TssfacturasClientesBases)
                .HasForeignKey(d => d.FtsId)
                .HasConstraintName("FK_TSSFacturasClientesBases_TSSFacturasClientes");
        });

        modelBuilder.Entity<TssfacturasClientesEliminada>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.FacIdContador });

            entity.ToTable("TSSFacturasClientesEliminadas");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.FacIdContador).HasColumnName("FAC_IdContador");
        });

        modelBuilder.Entity<TssfacturasClientesLinea>(entity =>
        {
            entity.HasKey(e => e.FslId).HasName("PK_TTSFacturasClientesLineas");

            entity.ToTable("TSSFacturasClientesLineas");

            entity.HasIndex(e => new { e.FtsId, e.FacIdVenta, e.FacIdLineaVenta }, "IX_TSSFacturasClientesLineas").IsUnique();

            entity.Property(e => e.FslId).HasColumnName("FSL_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.ArtFamilia).HasColumnName("ART_Familia");
            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.FacIdLineaVenta).HasColumnName("FAC_IdLineaVenta");
            entity.Property(e => e.FacIdVenta).HasColumnName("FAC_IdVenta");
            entity.Property(e => e.FslDescrip)
                .HasMaxLength(100)
                .HasColumnName("FSL_Descrip");
            entity.Property(e => e.FslFecha)
                .HasColumnType("datetime")
                .HasColumnName("FSL_Fecha");
            entity.Property(e => e.FslImpAporta)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FSL_ImpAporta");
            entity.Property(e => e.FslImpBruto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FSL_ImpBruto");
            entity.Property(e => e.FslImpDtos)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FSL_ImpDtos");
            entity.Property(e => e.FslImpNeto)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FSL_ImpNeto");
            entity.Property(e => e.FslMostrar).HasColumnName("FSL_Mostrar");
            entity.Property(e => e.FslNumDoc)
                .HasMaxLength(15)
                .HasColumnName("FSL_NumDoc");
            entity.Property(e => e.FslOcultar).HasColumnName("FSL_Ocultar");
            entity.Property(e => e.FslPorImpuesto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("FSL_PorImpuesto");
            entity.Property(e => e.FslPrecio)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("FSL_Precio");
            entity.Property(e => e.FslRecetaPendiente)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FSL_RecetaPendiente");
            entity.Property(e => e.FslTipoAporta)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FSL_TipoAporta");
            entity.Property(e => e.FslUnidades).HasColumnName("FSL_Unidades");
            entity.Property(e => e.FtsId).HasColumnName("FTS_ID");

            entity.HasOne(d => d.Fts).WithMany(p => p.TssfacturasClientesLineas)
                .HasForeignKey(d => d.FtsId)
                .HasConstraintName("FK_TTSFacturasClientesLineas_TSSFacturasClientes1");
        });

        modelBuilder.Entity<TssprocesoAux>(entity =>
        {
            entity.HasKey(e => e.TsxId);

            entity.ToTable("TSSProcesoAux");

            entity.Property(e => e.TsxId).HasColumnName("TSX_ID");
            entity.Property(e => e.ClrId).HasColumnName("CLR_ID");
            entity.Property(e => e.TivId).HasColumnName("TIV_ID");
            entity.Property(e => e.TsxBaseLiq)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSX_BaseLiq");
            entity.Property(e => e.TsxCuotaLiq)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSX_CuotaLiq");
            entity.Property(e => e.TsxDesde)
                .HasColumnType("datetime")
                .HasColumnName("TSX_Desde");
            entity.Property(e => e.TsxEjercicio).HasColumnName("TSX_Ejercicio");
            entity.Property(e => e.TsxHasta)
                .HasColumnType("datetime")
                .HasColumnName("TSX_Hasta");
            entity.Property(e => e.TsxImpAddMe)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSX_ImpAddME");
            entity.Property(e => e.TsxImpBaseMe)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSX_ImpBaseME");
            entity.Property(e => e.TsxImpFijoMe)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSX_ImpFijoME");
            entity.Property(e => e.TsxImpMeliq)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSX_ImpMELiq");
            entity.Property(e => e.TsxMes).HasColumnName("TSX_Mes");
            entity.Property(e => e.TsxPorImpuesto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("TSX_PorImpuesto");
            entity.Property(e => e.TsxTotalLiq)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSX_TotalLiq");
            entity.Property(e => e.TsxUdsCalMe).HasColumnName("TSX_UdsCalME");
            entity.Property(e => e.TsxUdsTotalMe).HasColumnName("TSX_UdsTotalME");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");

            entity.HasOne(d => d.Clr).WithMany(p => p.TssprocesoAuxes)
                .HasForeignKey(d => d.ClrId)
                .HasConstraintName("FK_TSSProcesoAux_TSSClientes");

            entity.HasOne(d => d.Tiv).WithMany(p => p.TssprocesoAuxes)
                .HasForeignKey(d => d.TivId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TSSProcesoAux_TiposIVA");

            entity.HasOne(d => d.Unn).WithMany(p => p.TssprocesoAuxes)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_TSSProcesoAux_UnidadesNegocio");

            entity.HasMany(d => d.Fts).WithMany(p => p.Tsxes)
                .UsingEntity<Dictionary<string, object>>(
                    "TssprocesoAuxFac",
                    r => r.HasOne<TssfacturasCliente>().WithMany()
                        .HasForeignKey("FtsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TSSProcesoAuxFac_TSSFacturasClientes"),
                    l => l.HasOne<TssprocesoAux>().WithMany()
                        .HasForeignKey("TsxId")
                        .HasConstraintName("FK_TSSProcesoAuxFac_TSSProcesoAux"),
                    j =>
                    {
                        j.HasKey("TsxId", "FtsId");
                        j.ToTable("TSSProcesoAuxFac");
                        j.IndexerProperty<int>("TsxId").HasColumnName("TSX_ID");
                        j.IndexerProperty<int>("FtsId").HasColumnName("FTS_ID");
                    });
        });

        modelBuilder.Entity<TssprocesoAuxLinea>(entity =>
        {
            entity.HasKey(e => new { e.TsxId, e.ArtCodigo, e.TslTipo });

            entity.ToTable("TSSProcesoAuxLineas");

            entity.Property(e => e.TsxId).HasColumnName("TSX_ID");
            entity.Property(e => e.ArtCodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_Codigo");
            entity.Property(e => e.TslTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TSL_Tipo");
            entity.Property(e => e.ArtFamilia).HasColumnName("ART_Familia");
            entity.Property(e => e.TaeId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAE_ID");
            entity.Property(e => e.TslBaseCalculo)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSL_BaseCalculo");
            entity.Property(e => e.TslDescripcion)
                .HasMaxLength(100)
                .HasColumnName("TSL_Descripcion");
            entity.Property(e => e.TslImporteLiq)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("TSL_ImporteLiq");
            entity.Property(e => e.TslModoCalculo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TSL_ModoCalculo");
            entity.Property(e => e.TslPorcentajeLiq)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("TSL_PorcentajeLiq");
            entity.Property(e => e.TslUds).HasColumnName("TSL_Uds");

            entity.HasOne(d => d.Tsx).WithMany(p => p.TssprocesoAuxLineas)
                .HasForeignKey(d => d.TsxId)
                .HasConstraintName("FK_TSSProcesoAuxLineas_TSSProcesoAux");
        });

        modelBuilder.Entity<TsstclnoGestion>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.TclId });

            entity.ToTable("TSSTCLNoGestion");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.TclId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_ID");
            entity.Property(e => e.TclClase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_Clase");

            entity.HasOne(d => d.Unn).WithMany(p => p.TsstclnoGestions)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_TSSTCLNoGestion_UnidadesNegocio");
        });

        modelBuilder.Entity<TsstiposCliente>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.TclId });

            entity.ToTable("TSSTiposCliente");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.TclId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_ID");
            entity.Property(e => e.TclClase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_Clase");
            entity.Property(e => e.TclDescrip)
                .HasMaxLength(25)
                .HasColumnName("TCL_Descrip");
            entity.Property(e => e.TclIdpadre)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_IDPadre");
            entity.Property(e => e.TclLiquida)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCL_Liquida");

            entity.HasOne(d => d.Unn).WithMany(p => p.TsstiposClientes)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_TSSTiposCliente_UnidadesNegocio");

            entity.HasOne(d => d.TsstiposClienteNavigation).WithMany(p => p.InverseTsstiposClienteNavigation)
                .HasForeignKey(d => new { d.UnnId, d.TclIdpadre })
                .HasConstraintName("FK_TSSTiposCliente_TSSTiposCliente");
        });

        modelBuilder.Entity<Ubdtraspaso>(entity =>
        {
            entity.HasKey(e => e.FilaId).HasName("PK_Unificacion_Traspaso");

            entity.ToTable("UBDTraspaso");

            entity.Property(e => e.FilaId).HasColumnName("fila_id");
            entity.Property(e => e.ArticuloCodigo).HasMaxLength(6);
            entity.Property(e => e.ArticuloDescripcion).HasMaxLength(30);
            entity.Property(e => e.ArticuloPvp).HasMaxLength(6);
            entity.Property(e => e.BonificacionPorc).HasMaxLength(5);
            entity.Property(e => e.CodNacional).HasMaxLength(6);
            entity.Property(e => e.CodigoCofaresLab).HasMaxLength(5);
            entity.Property(e => e.CodigoLaboratorioOld)
                .HasMaxLength(4)
                .HasColumnName("CodigoLaboratorio_old");
            entity.Property(e => e.ConCaducidad).HasMaxLength(1);
            entity.Property(e => e.GrupoTerapeutico).HasMaxLength(6);
            entity.Property(e => e.GrupoTerapeuticoOld)
                .HasMaxLength(6)
                .HasColumnName("GrupoTerapeutico_old");
            entity.Property(e => e.Marca).HasMaxLength(1);
            entity.Property(e => e.MarcaSoe)
                .HasMaxLength(1)
                .HasColumnName("MarcaSOE");
            entity.Property(e => e.PackSize).HasMaxLength(5);
            entity.Property(e => e.PrecioLabSinIva).HasMaxLength(8);
            entity.Property(e => e.TipoAportacion).HasMaxLength(1);
            entity.Property(e => e.TipoArticulo).HasMaxLength(2);
            entity.Property(e => e.TipoArticuloOld)
                .HasMaxLength(2)
                .HasColumnName("TipoArticulo_old");
            entity.Property(e => e.TipoIva).HasMaxLength(1);
            entity.Property(e => e.TipoPrecio).HasMaxLength(1);
            entity.Property(e => e.UsaFrigorifico).HasMaxLength(1);
        });

        modelBuilder.Entity<UnidadNegocio>(entity =>
        {
            entity.HasKey(e => e.UnnId);

            entity.ToTable("UnidadesNegocio");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.GpeId).HasColumnName("GPE_ID");
            entity.Property(e => e.UnnActiva).HasColumnName("UNN_Activa");
            entity.Property(e => e.UnnCanonTrebol).HasColumnName("UNN_CanonTrebol");
            entity.Property(e => e.UnnCoefRrhhventa)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("UNN_CoefRRHHVenta");
            entity.Property(e => e.UnnEsAlmacen).HasColumnName("UNN_EsAlmacen");
            entity.Property(e => e.UnnEsAlmacenTrebol).HasColumnName("UNN_EsAlmacenTrebol");
            entity.Property(e => e.UnnEsCentral).HasColumnName("UNN_EsCentral");
            entity.Property(e => e.UnnFalta)
                .HasComment("Fecha de Alta")
                .HasColumnType("datetime")
                .HasColumnName("UNN_FAlta");
            entity.Property(e => e.UnnFarmatic).HasColumnName("UNN_Farmatic");
            entity.Property(e => e.UnnFbajaTrebol)
                .HasColumnType("datetime")
                .HasColumnName("UNN_FBajaTrebol");
            entity.Property(e => e.UnnFincTrebol)
                .HasColumnType("datetime")
                .HasColumnName("UNN_FIncTrebol");
            entity.Property(e => e.UnnFmodificacion)
                .HasComment("Fecha Modificación")
                .HasColumnType("datetime")
                .HasColumnName("UNN_FModificacion");
            entity.Property(e => e.UnnIdSoe)
                .HasMaxLength(4)
                .HasColumnName("UNN_IdSOE");
            entity.Property(e => e.UnnModeloDual).HasColumnName("UNN_ModeloDual");
            entity.Property(e => e.UnnNombre)
                .HasMaxLength(150)
                .HasColumnName("UNN_Nombre");
            entity.Property(e => e.UnnTiendaWeb).HasColumnName("UNN_TiendaWeb");
            entity.Property(e => e.UnnTrebol)
                .HasMaxLength(5)
                .HasColumnName("UNN_Trebol");
            entity.Property(e => e.UnnUalta)
                .HasComment("Id. Usuario Alta")
                .HasColumnName("UNN_UAlta");
            entity.Property(e => e.UnnUmodificacion)
                .HasComment("Identificador del último Usuario que modificó")
                .HasColumnName("UNN_UModificacion");
            entity.Property(e => e.UnnWeb)
                .HasMaxLength(255)
                .HasColumnName("UNN_Web");

            entity.HasOne(d => d.Gpe).WithMany(p => p.UnidadesNegocios)
                .HasForeignKey(d => d.GpeId)
                .HasConstraintName("FK_UnidadesNegocio_GrupoPedidos");
        });

        modelBuilder.Entity<UnidadesNegocioCf>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.CafAno, e.CafId });

            entity.ToTable("UnidadesNegocioCF");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.CafAno).HasColumnName("CAF_ANO");
            entity.Property(e => e.CafId).HasColumnName("CAF_ID");

            entity.HasOne(d => d.Caf).WithMany(p => p.UnidadesNegocioCfs)
                .HasForeignKey(d => d.CafId)
                .HasConstraintName("FK_UnidadesNegocioCF_CalendarioFestivos");

            entity.HasOne(d => d.Unn).WithMany(p => p.UnidadesNegocioCfs)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_UnidadesNegocioCF_UnidadesNegocio");
        });

        modelBuilder.Entity<UnidadesNegocioCie>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.UciFiniCierre });

            entity.ToTable("UnidadesNegocioCIE");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.UciFiniCierre)
                .HasColumnType("datetime")
                .HasColumnName("UCI_FIniCierre");
            entity.Property(e => e.UciFfinCierre)
                .HasColumnType("datetime")
                .HasColumnName("UCI_FFinCierre");
            entity.Property(e => e.UciTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UCI_Tipo");

            entity.HasOne(d => d.Unn).WithMany(p => p.UnidadesNegocioCies)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_UnidadesNegocioCIE_UnidadesNegocio");
        });

        modelBuilder.Entity<UnidadNegocioDb>(entity =>
        {
            entity.HasKey(e => e.UnnId).HasName("PK_UnidadesNegocioDB_Real");

            entity.ToTable("UnidadesNegocioDB");

            entity.Property(e => e.UnnId)
                .ValueGeneratedNever()
                .HasColumnName("UNN_ID");
            entity.Property(e => e.UnnDbname)
                .HasMaxLength(255)
                .HasColumnName("UNN_DBName");
            entity.Property(e => e.UnnDbnameLs)
                .HasMaxLength(255)
                .HasColumnName("UNN_DBNameLS");
            entity.Property(e => e.UnnDbpass)
                .HasMaxLength(255)
                .HasColumnName("UNN_DBPass");
            entity.Property(e => e.UnnDbserver)
                .HasMaxLength(255)
                .HasColumnName("UNN_DBServer");
            entity.Property(e => e.UnnDbserverLs)
                .HasMaxLength(255)
                .HasColumnName("UNN_DBServerLS");
            entity.Property(e => e.UnnDbuser)
                .HasMaxLength(255)
                .HasColumnName("UNN_DBUser");

            entity.HasOne(d => d.UnidadNegocio).WithOne(p => p.UnidadNegocioDb)
                .HasForeignKey<UnidadNegocioDb>(d => d.UnnId)
                .HasConstraintName("FK_UnidadesNegocioDB_UnidadesNegocio");
        });

        modelBuilder.Entity<UnidadNegocioDireccion>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.DirId });

            entity.ToTable("UnidadesNegocioDirs");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.DirId).HasColumnName("DIR_ID");
            entity.Property(e => e.DirDefecto).HasColumnName("DIR_Defecto");
            entity.Property(e => e.DirFax1)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX1");
            entity.Property(e => e.DirFax2)
                .HasMaxLength(15)
                .HasColumnName("DIR_FAX2");
            entity.Property(e => e.DirTelf1)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf1");
            entity.Property(e => e.DirTelf2)
                .HasMaxLength(15)
                .HasColumnName("DIR_Telf2");

            entity.HasOne(d => d.Dir).WithMany(p => p.UnidadNegocioDirecciones)
                .HasForeignKey(d => d.DirId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UnidadesNegocioDirs_Direcciones");

            entity.HasOne(d => d.UnidadNegocio).WithMany(p => p.UnidadNegocioDirecciones)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_UnidadesNegocioDirs_UnidadesNegocio");
        });

        modelBuilder.Entity<UnidadesNegocioObj>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.ObvAno, e.ObvMes, e.LneId }).HasName("PK_UnidadesNegocioOBJ_1");

            entity.ToTable("UnidadesNegocioOBJ");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.ObvAno).HasColumnName("OBV_Ano");
            entity.Property(e => e.ObvMes).HasColumnName("OBV_Mes");
            entity.Property(e => e.LneId).HasColumnName("LNE_ID");
            entity.Property(e => e.ObvCerrado).HasColumnName("OBV_Cerrado");
            entity.Property(e => e.ObvLibre)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("OBV_Libre");
            entity.Property(e => e.ObvSoe)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("OBV_SOE");

            entity.HasOne(d => d.Unn).WithMany(p => p.UnidadesNegocioObjs)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_UnidadesNegocioOBJ_UnidadesNegocio");
        });

        modelBuilder.Entity<UnidadesNegocioSoc>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.SocId });

            entity.ToTable("UnidadesNegocioSoc");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.SocId).HasColumnName("SOC_ID");
            entity.Property(e => e.FpaId).HasColumnName("FPA_ID");
            entity.Property(e => e.SocFacTrebol).HasColumnName("SOC_FacTrebol");
            entity.Property(e => e.SocTitular).HasColumnName("SOC_Titular");

            entity.HasOne(d => d.Fpa).WithMany(p => p.UnidadesNegocioSocs)
                .HasForeignKey(d => d.FpaId)
                .HasConstraintName("FK_UnidadesNegocioSoc_FormasPago");

            entity.HasOne(d => d.Soc).WithMany(p => p.UnidadesNegocioSocs)
                .HasForeignKey(d => d.SocId)
                .HasConstraintName("FK_UnidadesNegocioSoc_Sociedades");

            entity.HasOne(d => d.Unn).WithMany(p => p.UnidadesNegocioSocs)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_UnidadesNegocioSoc_UnidadesNegocio");
        });

        modelBuilder.Entity<UnidadesNegocioVf>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.VefId });

            entity.ToTable("UnidadesNegocioVF");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");
            entity.Property(e => e.VefBaja).HasColumnName("VEF_Baja");
            entity.Property(e => e.VefColor).HasColumnName("VEF_Color");
            entity.Property(e => e.VefGenerico).HasColumnName("VEF_Generico");
            entity.Property(e => e.VefNombre)
                .HasMaxLength(25)
                .HasColumnName("VEF_Nombre");

            entity.HasOne(d => d.Unn).WithMany(p => p.UnidadesNegocioVfs)
                .HasForeignKey(d => d.UnnId)
                .HasConstraintName("FK_UnidadesNegocioVF_UnidadesNegocio");
        });

        modelBuilder.Entity<UnidadesNegocioW>(entity =>
        {
            entity.HasKey(e => e.WsId);

            entity.ToTable("UnidadesNegocioWS");

            entity.Property(e => e.WsId).HasColumnName("WS_ID");
            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.WsEstado).HasColumnName("WS_Estado");
            entity.Property(e => e.WsFecha)
                .HasColumnType("datetime")
                .HasColumnName("WS_Fecha");
            entity.Property(e => e.WsIp)
                .HasMaxLength(255)
                .HasColumnName("WS_IP");
        });

        modelBuilder.Entity<UnificacionClientesAuditoriaCliente>(entity =>
        {
            entity.HasKey(e => new { e.UnifId, e.CliIdunificado });

            entity.Property(e => e.UnifId).HasColumnName("UNIF_ID");
            entity.Property(e => e.CliIdunificado).HasColumnName("CLI_IDUnificado");

            entity.HasOne(d => d.Unif).WithMany(p => p.UnificacionClientesAuditoriaClientes)
                .HasForeignKey(d => d.UnifId)
                .HasConstraintName("FK_UnificacionClientesAuditoriaClientes_UnificacionClientesAuditoria");
        });

        modelBuilder.Entity<UnificacionClientesAuditorium>(entity =>
        {
            entity.HasKey(e => e.UnifId);

            entity.Property(e => e.UnifId).HasColumnName("UNIF_ID");
            entity.Property(e => e.CliIdmantener).HasColumnName("CLI_IDMantener");
            entity.Property(e => e.CliIdunificarApellidos).HasColumnName("CLI_IDUnificarApellidos");
            entity.Property(e => e.CliIdunificarDir).HasColumnName("CLI_IDUnificarDir");
            entity.Property(e => e.CliIdunificarEmail).HasColumnName("CLI_IDUnificarEmail");
            entity.Property(e => e.CliIdunificarFnac).HasColumnName("CLI_IDUnificarFnac");
            entity.Property(e => e.CliIdunificarIdFiscal).HasColumnName("CLI_IDUnificarIdFiscal");
            entity.Property(e => e.CliIdunificarMovil).HasColumnName("CLI_IDUnificarMovil");
            entity.Property(e => e.CliIdunificarNombre).HasColumnName("CLI_IDUnificarNombre");
            entity.Property(e => e.CliIdunificarTelf).HasColumnName("CLI_IDUnificarTelf");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.UsrId).HasColumnName("USR_ID");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsrId);

            entity.Property(e => e.UsrId)
                .HasComment("Identificador de Usuario")
                .HasColumnName("USR_ID");
            entity.Property(e => e.PeaId)
                .HasComment("Identificador del perfil de Acceso")
                .HasColumnName("PEA_ID");
            entity.Property(e => e.TstId).HasColumnName("TST_ID");
            entity.Property(e => e.UsrAdmin).HasColumnName("USR_Admin");
            entity.Property(e => e.UsrAvisoSegLogin).HasColumnName("USR_AvisoSegLogin");
            entity.Property(e => e.UsrCambiarLogin).HasColumnName("USR_CambiarLogin");
            entity.Property(e => e.UsrFalta)
                .HasComment("Fecha de Alta")
                .HasColumnType("datetime")
                .HasColumnName("USR_FAlta");
            entity.Property(e => e.UsrFirmaPedidos).HasColumnName("USR_FirmaPedidos");
            entity.Property(e => e.UsrFmodificacion)
                .HasComment("Fecha Modificación")
                .HasColumnType("datetime")
                .HasColumnName("USR_FModificacion");
            entity.Property(e => e.UsrGestorPartners).HasColumnName("USR_GestorPartners");
            entity.Property(e => e.UsrHabilitado).HasColumnName("USR_Habilitado");
            entity.Property(e => e.UsrLogin)
                .HasMaxLength(15)
                .HasColumnName("USR_Login");
            entity.Property(e => e.UsrMail)
                .HasMaxLength(255)
                .HasColumnName("USR_Mail");
            entity.Property(e => e.UsrNombre)
                .HasMaxLength(50)
                .HasComment("Nombre del usuario")
                .HasColumnName("USR_Nombre");
            entity.Property(e => e.UsrPassword)
                .HasMaxLength(25)
                .HasColumnName("USR_Password");
            entity.Property(e => e.UsrUalta)
                .HasComment("Id. Usuario alta")
                .HasColumnName("USR_UAlta");
            entity.Property(e => e.UsrUmodificacion)
                .HasComment("Identificador del último Usuario que modificó")
                .HasColumnName("USR_UModificacion");

            entity.HasOne(d => d.Perfil).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PeaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_PerfilesAcceso");

            entity.HasMany(d => d.Consultas).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuariosConsulta",
                    r => r.HasOne<ConsultaSql>().WithMany()
                        .HasForeignKey("ConId")
                        .HasConstraintName("FK_UsuariosConsultas_ConsultasSQL"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsrId")
                        .HasConstraintName("FK_UsuariosConsultas_Usuarios"),
                    j =>
                    {
                        j.HasKey("UsrId", "ConId");
                        j.ToTable("UsuariosConsultas");
                        j.IndexerProperty<int>("UsrId").HasColumnName("USR_ID");
                        j.IndexerProperty<int>("ConId").HasColumnName("CON_ID");
                    });
        });

        modelBuilder.Entity<UsuarioJwtRefresh>(entity =>
        {
            entity.HasKey(e => e.UsrId);
            entity.Property(e => e.UsrId)
                  .HasComment("Identificador de Usuario")
                  .HasColumnName("USR_ID");
            entity.Property(e => e.UsrLogin)
                .HasMaxLength(15)
                .HasComment("Nombre de Usuario")
                .HasColumnName("USR_Login");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(255)
                .HasComment("Token de Refresco JWT")
                .HasColumnName("USR_JwtRefreshToken");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("datetime")
                .HasComment("Fecha de Expiración del Token de Refresco")
                .HasColumnName("USR_JwtRefreshTokenExpiry");

            entity.ToTable("UsuariosJwtRefresh");

            entity.HasOne(d => d.Usuario).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d. UsrId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UsuariosJwtRefresh_Usuarios");
        });

        modelBuilder.Entity<UsuariosUpn>(entity =>
        {
            entity.HasKey(e => e.UpnId).HasName("PK__Usuarios__22480ECF8C0DE1EE");

            entity.ToTable("UsuariosUPN");

            entity.Property(e => e.UpnId).HasColumnName("UPN_ID");
            entity.Property(e => e.Usuario).HasMaxLength(255);

            entity.HasMany(d => d.Unns).WithMany(p => p.Upns)
                .UsingEntity<Dictionary<string, object>>(
                    "FarmaciasUpn",
                    r => r.HasOne<UnidadNegocio>().WithMany()
                        .HasForeignKey("UnnId")
                        .HasConstraintName("FK_FarmaciasUPN_UnidadesNegocio"),
                    l => l.HasOne<UsuariosUpn>().WithMany()
                        .HasForeignKey("UpnId")
                        .HasConstraintName("FK_FarmaciasUPN_UsuariosUPN"),
                    j =>
                    {
                        j.HasKey("UpnId", "UnnId");
                        j.ToTable("FarmaciasUPN");
                        j.IndexerProperty<int>("UpnId").HasColumnName("UPN_ID");
                        j.IndexerProperty<int>("UnnId").HasColumnName("UNN_ID");
                    });
        });

        modelBuilder.Entity<VendedoresUso>(entity =>
        {
            entity.HasKey(e => new { e.UnnId, e.VefId, e.UsrId });

            entity.ToTable("VendedoresUso");

            entity.Property(e => e.UnnId).HasColumnName("UNN_ID");
            entity.Property(e => e.VefId).HasColumnName("VEF_ID");
            entity.Property(e => e.UsrId)
                .HasComment("Identificador de Usuario")
                .HasColumnName("USR_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
