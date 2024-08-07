import { useState } from 'react';
import './App.css';


const App = () => {
  const [items, setItems] = useState([
    "oranges", "apples", "candy"
  ]);
  return (
    <div id="list-container">
      <ListDisplay items={items} handleClick={(item: string) => { setItems(items.slice().filter((i) => i !== item));
      }}/>
      <InputText handleSubmit={(item: string) => {
        if (item !== "") {
          setItems(items.concat(item));
          }
        }}
      />
    </div>
  )
}

const ListItem = (props: any) => (
  <li>
    {props.name}
    <div>
      <button onClick={() => props.handleClick(props.name)} type="button">X</button>
    </div>
  </li>
)

const ListDisplay = (props: any) => {
  const items = props.items.map((item: string, i: number) => (
    <ListItem
      key={i}
      name={item}
      handleClick={props.handleClick}
    />
  ))
  return (
    <ul>
      {items}
    </ul>
  )
}

const InputText = (props: any) => {
  const [value, setValue] = useState('');
  return (
    <form id="form">
      <input type="text" value={value} onChange={e => setValue(e.target.value)} />
      <button type="button" onClick={() => {
        props.handleSubmit(value);
        setValue('');
      }}>Add</button>
    </form>
  )
}


export default App;