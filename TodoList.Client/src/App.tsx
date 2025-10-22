import "./App.css";
import { Card, CardContent, CardHeader, CardTitle } from "./components/ui/card";
import useFetch from "./hooks/useFetch";
import { Input } from "./components/ui/input";
import { useState } from "react";
import { Button } from "./components/ui/button";
import axios from "axios";
import { Label } from "./components/ui/label";
import { Separator } from "./components/ui/separator";

const apiUrl = "https://localhost:7037";
interface Task {
  id: number;
  title: string;
  description: string;
}

function DisplayTask({ task }: { task: Task }) {
  return (
    <Card>
      <CardHeader>
        <CardTitle>{task.title}</CardTitle>
      </CardHeader>
      <CardContent>
        <>
          <Separator className="m4" />
          {task.description}
        </>
      </CardContent>
    </Card>
  );
}

function DisplayTasks({ tasks }: { tasks: Task[] }) {
  return (
    <>
      {tasks.map((task) => (
        <DisplayTask
          task={task}
          key={task.id}
        />
      ))}
    </>
  );
}

function AddTask() {
  const [title, setTitle] = useState<string>("");
  const [desc, setDesc] = useState<string>("");

  const SendData = () => {
    const newTask: Omit<Task, "id"> = {
      title,
      description: desc,
    };

    axios.post(`${apiUrl}/api/TodoTask`, newTask);
  };

  return (
    <div className="flex items-end gap-4">
      <div className="flex flex-col basis-1/4 gap-2">
        <Label htmlFor="title">Title</Label>
        <Input
          id="title"
          type="text"
          value={title}
          onChange={(t) => setTitle(t.target.value)}
        />
      </div>

      <div className="flex flex-col flex-1 gap-2 items-end">
        <Label htmlFor="desc">Description</Label>
        <Input
          id="desc"
          type="text"
          value={desc}
          onChange={(t) => setDesc(t.target.value)}
        />
      </div>

      <Button
        variant="outline"
        onClick={SendData}
      >
        Add
      </Button>
    </div>
  );
}

function App() {
  const apiCall = useFetch<Task[]>(`${apiUrl}/api/TodoTask`);

  if (apiCall.data) {
    return (
      <>
        <AddTask />
        <DisplayTasks tasks={apiCall.data}></DisplayTasks>;
      </>
    );
  } else if (apiCall.loading) {
    return <p>Loading</p>;
  } else return <p>{apiCall.error}</p>;
}

export default App;
