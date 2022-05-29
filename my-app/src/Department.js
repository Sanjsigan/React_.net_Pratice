import React, {Component} from 'react';
import { Table, Button, ButtonToolbar } from 'react-bootstrap';
import { AddDepModel } from './AddDepModel';


export class Department extends Component {

constructor(props){
    super(props)
    this.state={deps:[],addModelShow:false}
} 

refreshlist(){
    fetch(process.env.REACT_APP_API+'department' )
    .then(res=>res.json())
    .then(data=>{
        this.setState({deps:data});
    })
} 

componentDidMount(){
    this.refreshlist();
}

componentDidUpdate(){
    this.refreshlist();
}

    render(){
        const{deps}=this.state;
        let addmodelclose =()=>{this.setState({addModelShow:false})}
        return(
            <div>
                <Table className='mt-4'>
                       <thead>
                           <tr>
                           <th>Department Id</th>
                           <th>Department Name</th>
                           <th>Options</th>
                           </tr>
                       </thead>

                       <tbody>
                           {deps.map(dep=>(
                               <tr key={dep.DepartmentId}>
                                  <td>{dep.DepartmentId}</td>
                                  <td>{dep.DepartmentName}</td>
                                  <td>Edit / Delete</td>
  
                               </tr>
                           ))}
                       </tbody>
                </Table>

                <ButtonToolbar>
                    <Button onClick={()=>this.setState({addModelShow:true})}>
                        Add Department
                    </Button>

                    <AddDepModel show={this.state.addModelShow} onHide={addmodelclose}/>
                </ButtonToolbar>
            </div>
        )
    }
}