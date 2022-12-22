export interface Node {
    id:string;
    name:string;
    isExpanded:boolean;
    children?:Node[];
}
