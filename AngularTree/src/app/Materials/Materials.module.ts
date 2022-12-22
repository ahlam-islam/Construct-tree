import { NgModule } from '@angular/core';
import { MatTreeModule } from '@angular/material/tree';
import { MatIconModule } from '@angular/material/icon';

const modules = [MatTreeModule, MatIconModule]
@NgModule({
  imports: [
    modules
  ]
  , exports: [modules]
})
export class MaterialsModule { }
