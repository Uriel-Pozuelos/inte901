import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { TestComponent } from './test/test.component';
import { AuthGuard } from './auth/login.guard';
import { AuthenticatedGuard } from './auth/route.guard';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { NavComponent } from './layout/nav/nav.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';

import { PedidoStateComponent } from './pedido-state/pedido-state.component';

import { ProductDetailComponent } from './product-detail/product-detail.component';
import { PlaceComponent } from './place/place.component';


export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [AuthGuard], // Este guardia redirige a los usuarios autenticados fuera del login
  },
  {
    path: 'test',
    component: TestComponent// Este guardia protege las rutas autenticadas
  },
  {
    path: '',
    component: LandingPageComponent
  },
  {
    path:'products',
    component: HomeComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'home',
    component: NavComponent
  },{
    path: 'estatus',
    component: PedidoStateComponent
  },
  {
    path:'products/:id',
    component: ProductDetailComponent
  },
  {
    path:'place',
    component: PlaceComponent
  }
];
