import {NestedTreeControl} from '@angular/cdk/tree';
import {Component , OnInit} from '@angular/core';
import {MatTreeNestedDataSource} from '@angular/material/tree';
import {Node} from '../Classes/Node';
import { NodeService } from '../Services/Node.service';

@Component({
  selector: 'app-Tree',
  templateUrl: './Tree.component.html',
  styleUrls: ['./Tree.component.css']
})

export class TreeComponent implements OnInit {

  flag:boolean = false
  AddedFlag:boolean = false
  EditFlag:boolean = false
  NodeId:string =""
  treeControl = new NestedTreeControl<Node>(node => node.children);
  dataSource = new MatTreeNestedDataSource<Node>();
  createNode:Node ={id:"",name:"",isExpanded:false,children:[]}
  updatedNode:Node | any

  constructor(public nodeService:NodeService) {
 
  }

  //Get all nodes from database to display
  ngOnInit(): void {
      this.nodeService.GetAllNodes().subscribe(data =>{
      this.dataSource.data = data
     })
  }
  hasChild = (_: number, node: Node) => !!node.children && node.children.length > 0;
 

  // show options when click on any node
  Options(id:string){
    this.flag = !this.flag
    this.NodeId = id;
    
  }

  // delete selected node
  Delete(){
    if(confirm("Are Youe Sure!")){
      this.nodeService.DeleteNode(this.NodeId).subscribe(err =>
        console.log(err))
    }
  }

  // show pop up box to add new node
  popUpBox(){
    this.AddedFlag = true
  }
  EditpopUpBox(){
    this.EditFlag = true
  }


  // add new node
  AddNode(value:string){
    this.createNode.name = value
    this.nodeService.AddNode(this.createNode).subscribe(error =>{
      console.log(error)
    })
    this.AddedFlag = false
  }


  // edit node
  Edit(value:string){
    this.nodeService.GetNode(this.NodeId).subscribe(data =>{
      this.updatedNode = data
      this.updatedNode.name = value
      console.log(this.updatedNode)
    })
    this.nodeService.UpdateNode(this.NodeId , this.updatedNode).subscribe(error =>{
      console.log(error)
    })
    this.EditFlag = false
  }


  closeBoxs(){
    this.AddedFlag = false
    this.EditFlag = false
  }
}
