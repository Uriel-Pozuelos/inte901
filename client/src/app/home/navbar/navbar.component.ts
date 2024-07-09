import { Component } from '@angular/core';
import { LucideAngularModule } from 'lucide-angular';
import { HlmInputDirective } from '~/components/ui-input-helm/src';
import { IconComponent } from '../icon/icon.component';

import { BrnCommandImports } from '@spartan-ng/ui-command-brain';
import { HlmCommandImports } from '@spartan-ng/ui-command-helm';
import { ProductosService } from '../services/productos.service';
import { NgFor, NgIf } from '@angular/common';
import { Producto } from '~/lib/types';
import { FormsModule } from '@angular/forms';
import { CartComponent } from '~/app/cart/cart.component';



@Component({
  selector: 'home-navbar',
  standalone: true,
  imports: [
    HlmInputDirective,
    LucideAngularModule,
    IconComponent,
    BrnCommandImports,
    HlmCommandImports,
    NgIf,
    NgFor,
    FormsModule,
    CartComponent
  ],
  providers: [ProductosService],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  items: Producto[] = [];
  filteredItems: Producto[] = [];
  dropdownOpen = false;
  searchTerm = '';
  currentFilter = 'Todo';

  constructor(private productService: ProductosService) {
    this.productService.getProductos().subscribe({
      next: (productos) => {
        this.items = productos;
        this.filteredItems = productos;
      },
      error: (error) => {
        console.error('Error al cargar los productos', error);
      },
      complete: () => {
        console.log('Productos cargados correctamente');
      }
    })
  }

  toggleDropdown() {
    this.dropdownOpen = !this.dropdownOpen;
  }

  setFilter(filter: string) {
    this.currentFilter = filter;
    this.filterItems();
    this.dropdownOpen = false; // Opcional: cerrar el dropdown al seleccionar un filtro
  }

  filterItems() {
    this.filteredItems = this.items.filter(item =>
      item.nombre.toLowerCase().includes(this.searchTerm.toLowerCase()) &&
      (this.currentFilter === 'Todo' || item.tipo === this.currentFilter)
    );
  }

  isLogged() {
    return !!localStorage.getItem('token');
  }

}
