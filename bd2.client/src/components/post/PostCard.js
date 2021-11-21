import React, { useState, useEffect } from "react";
import ImageGallery from "react-image-gallery";
import "react-image-gallery/styles/css/image-gallery.css";
import axios from "axios";
import PostComments from "./PostComments";

const PostCard = ({ postData, setPostData }) => {
  const fetchPostsDetails = async () => {
    const result = await axios.get(`/api/Posts/${postData.post.id}`);

    if (result && result.data && result.data.success) {
      setPostData({
        ...postData,
        detailsFetched: true,
        expanded: true,
        ...result.data.model,
      });
    }
  };

  const getImages = () => {
    return postData.images.map((x) => {
      return {
        original: "Images/" + x,
        thumbnail: "Images/" + x,
      };
    });
  };

  return (
    <>
      <div
        className="card m-4 p-4 pt-2 rounded rounded-lg w-100 shadow border border-dark rounded-0"
        style={{ border: "#8f8f8fb6" }}
      >
        <div>
          {postData.images && postData.images.length > 0 && (
            <ImageGallery
              items={getImages()}
              showBullets={true}
              showIndex={true}
              showThumbnails={false}
            />
          )}
        </div>

        <hr style={{ background: "black", marginBottom: 20, marginTop: 20 }} />
        {/* IMAGES carousel*/}
        <div className="d-flex flex-row justify-content-between">
          <div className="h5">
            {postData.owner.firstname + " " + postData.owner.lastname}
          </div>
          <div className="my-0 py-0 d-flex flex-row justify-content-between">
            <div className="mx-2 mt-1 h6">
              {postData.post.postDate.slice(0, 19).split("T").join("  ")}
              {/* TO DO: cut milieconds */}
            </div>

            <div
              className="mx-2 badge badge-pill badge-primary py-2"
              style={{ height: 30, fontSize: 13 }}
            >
              <i className="fa fa-thumbs-up mr-2" aria-hidden="true"></i>
              {postData.post.positiveReactionsCount}
            </div>
            <div
              className="mx-2 badge badge-pill badge-danger py-2"
              style={{ height: 30, fontSize: 13 }}
            >
              <i className="fa fa-thumbs-down mr-2" aria-hidden="true"></i>
              {postData.post.negativeReactionCount}
            </div>
            <div
              className="mx-2 badge badge-pill badge-warning py-2"
              style={{ height: 30, fontSize: 13 }}
            >
              <i className="fa fa-comment mr-2" aria-hidden="true"></i>
              {postData.post.commentsCount}
            </div>
          </div>
        </div>
        <div className="h5 justify-content-center text-center">
          {postData.post.title}
        </div>
        <div className="ma-4 pa-4" style={{ fontSize: 18 }}>
          {postData.post.text}
        </div>

        <div className=" mt-2">
          <PostComments
            comments={postData.comments}
            setComments={(comments) => setPostData([...postData, comments])}
            showComments={postData.expanded}
            postId={postData.post.id}
          />
          {!postData.expanded ? (
            <div
              className="mx-2 badge badge-pill badge-primary py-2 float-right"
              style={{ height: 30, fontSize: 13 }}
              onClick={() => {
                fetchPostsDetails()
                setPostData({ ...postData, expanded: true });
              }}
            >
              <i className="fa fa-arrow-down mr-2" aria-hidden="true"></i>
              <span className="float-right">Pokaż komentarze</span>
            </div>
          ) : (
            <div
              className="mx-2 badge badge-pill badge-secondary py-2"
              style={{ height: 30, fontSize: 13 }}
              onClick={() => {
                setPostData({ ...postData, expanded: false });
              }}
            >
              <i className="fa fa-arrow-up mr-2" aria-hidden="true"></i>
              <span className="float-right">Ukryj komentarze</span>
            </div>
          )}
        </div>
      </div>
    </>
  );
};

export default PostCard;
