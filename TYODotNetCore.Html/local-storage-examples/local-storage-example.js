const Tbl_Blog = "Tbl_Blog";

const runBlog = () => {
  readBlog();
  editBlog("1118672f-54ec-43db-8a66-f5909c04a51b");
  createBlog("title 1", "author 1", "content 1");
  updateBlog(
    "ce5dfedc-f4bc-437f-9e56-36a0bda8d39b",
    "title 2",
    "author 2",
    "content 2"
  );
  deleteBlog("4d2b68d7-f314-4066-ae49-ad6f2fea5376");
};

const readBlog = () => {
  let dataArr = getBlog();

  if (dataArr.length) {
    dataArr.forEach((data) => {
      console.log(data.id, data.title, data.author, data.content);
    });
  } else {
    console.log("NO DATA FOUND !!");
  }
};

const editBlog = (id) => {
  let dataArr = getBlog();

  let data = dataArr.find((ele) => ele.id === id);

  if (data) {
    console.log(data.id, data.title, data.author, data.content);
  } else {
    console.log("NO DATA FOUND !!");
  }
};

const createBlog = (title, author, content) => {
  let dataArr = getBlog();

  const data = {
    id: uuid(),
    title: title,
    author: author,
    content: content,
  };

  dataArr.push(data);
  localStorage.setItem(Tbl_Blog, JSON.stringify(dataArr));
};

const updateBlog = (id, title, author, content) => {
  let dataArr = getBlog();

  let data = dataArr.find((ele) => ele.id === id);

  if (data) {
    let index = dataArr.findIndex((ele) => ele.id === id);

    dataArr[index] = {
      id,
      title,
      author,
      content,
    };

    localStorage.setItem(Tbl_Blog, JSON.stringify(dataArr));
  } else {
    console.log("NO DATA FOUND !!");
  }
};

const deleteBlog = (id) => {
  let dataArr = getBlog();

  let data = dataArr.find((ele) => ele.id === id);

  if (data) {
    let balanceData = dataArr.filter((ele) => ele.id !== id);

    localStorage.setItem(Tbl_Blog, JSON.stringify(balanceData));
  } else {
    console.log("NO DATA FOUND !!");
  }
};

const getBlog = () => {
  let dataArr = [];

  let dataStr = localStorage.getItem(Tbl_Blog);

  if (dataStr) {
    dataArr = JSON.parse(dataStr);
  }

  return dataArr;
};

function uuid() {
  let d = new Date().getTime();
  const uuid = "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(
    /[xy]/g,
    function (c) {
      const r = (d + Math.random() * 16) % 16 | 0;
      d = Math.floor(d / 16);
      return (c === "x" ? r : (r & 0x3) | 0x8).toString(16);
    }
  );
  return uuid;
}

runBlog();
