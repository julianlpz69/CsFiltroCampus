using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
{

    private readonly TiendaRopaDBcontext _context; 
    
	private IRol _roles;
    private IUsuario _usuario;


    private ICargo _Cargo;
    private ICliente _Cliente;
    private IColor _Color;
    private IDepartamento _DeIDepartamento;
    private IDetalleOrden _DetallIDetalleOrden;
    private IDetalleVenta _DetaIDetalleVenta;
    private IEmpleado _Empleado;
    private IEmpresa _Empresa;
    private IEstado _Estado;
    private IFormaPago _FormaPago;
    private IGenero _Genero;
    private IInsumo _Insumo;
    private IInventario _Inventario;
    private IMunicipio _Municipio;
    private IOrden _Orden;
    private IPais _Pais;
    private IPrenda _Prenda;
    private IProveedor _Proveedor;
    private ITalla _Talla;
    private ITipoEstado _tipoEstado;
    private ITipoPersona _TipoPersona;
    private ITipoProteccion _TipoProteccion;
    private IVenta _Venta;


    public UnitOfWork(TiendaRopaDBcontext context){
        _context = context;
    }

   
    
    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }


    public IUsuario Usuarios
    {
        get
        {
            if (_usuario == null)
            {
                _usuario = new UsuarioRepository(_context);
            }
            return _usuario;
        }
    }



    public ICargo Cargos 
    {
        get{
            if (_Cargo == null)
            {
                _Cargo = new CargoRepository(_context);
            }
            return _Cargo;
        }
    }


    public ICliente Clientes
    {
        get{
            if (_Cliente == null)
            {
                _Cliente = new ClienteRepository(_context);
            }
            return _Cliente;
        }
    }


    public IColor Colors 
    {
        get{
            if (_Color == null)
            {
                _Color = new  ColorRepository(_context);
            }
            return _Color;
        }
    }

    public IDepartamento Departamentos
    {
        get{
            if (_DeIDepartamento == null)
            {
                _DeIDepartamento = new DepartamentoRepository(_context);
            }
            return _DeIDepartamento;
        }
    }



    public IDetalleOrden DetalleOrdenes
    {
        get{
            if (_DetallIDetalleOrden == null)
            {
                _DetallIDetalleOrden = new DetalleOrdenRepository(_context);
            }
            return _DetallIDetalleOrden;
        }
    }
    


    public IDetalleVenta DetalleVentas
    {
        get{
            if (_DetaIDetalleVenta == null)
            {
                _DetaIDetalleVenta = new DetalleVentaRepository(_context);
            }
            return _DetaIDetalleVenta;
        }
    }


    public IEmpleado Empleados
    {
        get{
            if (_Empleado == null)
            {
                _Empleado = new EmpleadoRepository(_context);
            }
            return _Empleado;
        }
    }


    public IEmpresa Empresas
    {
        get{
            if (_Empresa == null)
            {
                _Empresa = new EmpresaRepository(_context);
            }
            return _Empresa;
        }
    }


    public IEstado Estados
    {
        get{
            if (_Estado == null)
            {
                _Estado = new EstadoRepository(_context);
            }
            return _Estado;
        }
    }
   

    public IFormaPago FormaPagos
    {
        get{
            if (_FormaPago == null)
            {
                _FormaPago = new FormaPagoRepository(_context);
            }
            return _FormaPago;
        }
    }


    public IGenero Generos
    {
        get{
            if (_Genero == null)
            {
                _Genero = new GeneroRepository(_context);
            }
            return _Genero;
        }
    }



    public IInsumo Insumos
    {
        get{
            if (_Insumo == null)
            {
                _Insumo = new InsumoRepository(_context);
            }
            return _Insumo;
        }
    }


    public IInventario Inventarios
    {
        get{
            if (_Inventario == null)
            {
                _Inventario = new InventarioRepository(_context);
            }
            return _Inventario;
        }
    }



    public IMunicipio Municipios
    {
        get{
            if (_Municipio == null)
            {
                _Municipio = new MunicipioRepository(_context);
            }
            return _Municipio;
        }
    }



    public IOrden Ordenes
    {
        get{
            if (_Orden == null)
            {
                _Orden = new OrdenRepository(_context);
            }
            return _Orden;
        }
    }



    public IPais Paises
    {
        get{
            if (_Pais == null)
            {
                _Pais = new PaisRepository(_context);
            }
            return _Pais;
        }
    }


    public IPrenda Prendas
    {
        get{
            if (_Prenda == null)
            {
                _Prenda= new PrendaRepository(_context);
            }
            return _Prenda;
        }
    }


    public IProveedor Proveedores
    {
        get{
            if (_Proveedor == null)
            {
                _Proveedor = new ProveedorRepository(_context);
            }
            return _Proveedor;
        }
    }



    public ITalla Tallas
    {
        get{
            if (_Talla == null)
            {
                _Talla = new TallaRepository(_context);
            }
            return _Talla;
        }
    }


    public ITipoEstado TipoEstados
    {
        get{
            if (_tipoEstado == null)
            {
                _tipoEstado = new TipoEstadoRepository(_context);
            }
            return _tipoEstado;
        }
    }


    public ITipoPersona TipoPersonas
    {
        get{
            if (_TipoPersona == null)
            {
                _TipoPersona = new TipoPersonaRepository(_context);
            }
            return _TipoPersona;
        }
    }




    public ITipoProteccion TipoProtecciones
    {
        get{
            if (_TipoProteccion == null)
            {
                _TipoProteccion = new TipoProteccionRepository(_context);
            }
            return _TipoProteccion;
        }
    }


    public IVenta Ventas 
    {
        get{
            if (_Venta == null)
            {
                _Venta = new VentaRepository(_context);
            }
            return _Venta;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
